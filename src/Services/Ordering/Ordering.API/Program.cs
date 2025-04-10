using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container
//-----------------
//Infrastructure - EFCore
//Application - MediatR
//API - Carter, HealthChecks, Swagger

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServiceCollection(builder.Configuration)
    .AddApiServices();


var app = builder.Build();

//Configure the HTTP request pipeline.

app.MapGet("/", () => "Hello World!");

app.Run();