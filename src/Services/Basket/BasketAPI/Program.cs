using BuildingBlocks.Messaging.MassTransit;
using Discount.Grpc;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

//Application service
var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(
    config =>
    {
        config.RegisterServicesFromAssemblies(assembly);
        config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        config.AddOpenBehavior(typeof(LoggingBehavior<,>));
    }
);

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();


//Data service
builder.Services.AddMarten(
    opts =>
    {
        opts.Connection(builder.Configuration.GetConnectionString("Database")!);
        opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);
    }
).UseLightweightSessions();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.Decorate<IBasketRepository, CachedBasketRepository>();

builder.Services.AddStackExchangeRedisCache(
    options => { options.Configuration = builder.Configuration.GetConnectionString("Redis")!; }
);

//Grpc service
builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(
        opts =>
        {
            opts.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]!);
        }
    )
    .ConfigurePrimaryHttpMessageHandler(
        () =>
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                                                                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            return handler;
        }
    );

//Async communication service
builder.Services.AddMessageBroker(builder.Configuration);

//Cross-cutting concerns
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog API", Version = "v1" }); });


//Health check
builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("Database")!)
    .AddRedis(builder.Configuration.GetConnectionString("Redis")!);


var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog API V1");
            options.RoutePrefix = "swagger";
        }
    );
}

app.UseHealthChecks(
    "/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    }
);

app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();