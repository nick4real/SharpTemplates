using MSTemplate.Infrastructure;
using MSTemplate.Application;

// Builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

// Application
var app = builder.Build();

app.Run();
