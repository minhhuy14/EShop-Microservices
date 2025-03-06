var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(
    opts =>
    {
        opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    }
).UseLightweightSessions();

// if (builder.Environment.IsDevelopment())
// {
//     builder.Services.InitializeMartenWith<CatalogInitialData>();
// }

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog API", Version = "v1" });
});

// builder.Services.AddHealthChecks()
//     .AddNpgSql(builder.Configuration.GetConnectionString("Database")!);

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options=>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog API V1");
        options.RoutePrefix = "swagger";
    });
    
}

// app.UseHealthChecks("/health",
//     new HealthCheckOptions
//     {
//         ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
//     });

app.MapCarter();

app.UseExceptionHandler(options=>{});

app.Run();