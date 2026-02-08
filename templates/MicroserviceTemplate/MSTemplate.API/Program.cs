using MSTemplate.Infrastructure;
using MSTemplate.Application;
#if (EnableScalarSupport)
using Scalar.AspNetCore;
#endif

// Builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddControllers();
builder.Services.AddHealthChecks();

#if EnableScalarSupport
// OpenAPI support
builder.Services.AddOpenApi();

#endif
// Application
var app = builder.Build();

app.MapControllers();
app.MapHealthChecks("/health");

#if EnableScalarSupport
if (!app.Environment.IsProduction())
{
    app.MapOpenApi();
    // Map the Scalar API reference endpoint
    app.MapScalarApiReference();
}

#endif
app.Run();
