using MSTemplate.Infrastructure;
using MSTemplate.Application;
#if EnsuredDatabaseStrategy || AutoMigrationDatabaseStrategy
using Microsoft.EntityFrameworkCore;
using MSTemplate.Infrastructure.Persistence;
#endif
#if EnableScalarSupport
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

app.UseExceptionHandler();
#if EnableHttpsRedirection
app.UseHttpsRedirection();
#endif
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

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
#if EnsuredDatabaseStrategy || AutoMigrationDatabaseStrategy
// Database initialization
await using (var serviceScope = app.Services.CreateAsyncScope())
await using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>())
{
    var executionStrategy = dbContext.Database.CreateExecutionStrategy();

    if (!app.Environment.IsDevelopment())
        return;

#if AutoMigrationDatabaseStrategy
    await executionStrategy.ExecuteAsync(async () =>
    {
        // Make sure the database exists so migration history can be queried
        await dbContext.Database.EnsureCreatedAsync();

        var allMigrations = dbContext.Database.GetMigrations().ToList();
        var appliedMigrations = (await dbContext.Database.GetAppliedMigrationsAsync()).ToList();

        // Mismatch if:
        // 1) there are pending migrations, OR
        // 2) DB has migrations not present in code (e.g. due to branch switch)
        var hasPending = allMigrations.Except(appliedMigrations).Any();
        var hasUnknownApplied = appliedMigrations.Except(allMigrations).Any();

        if (hasPending)
        {
            await dbContext.Database.MigrateAsync();
        }
        else if (hasUnknownApplied)
        {
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.Database.MigrateAsync();
        }
    });
#endif
#if EnsuredDatabaseStrategy
    await executionStrategy.ExecuteAsync(async () =>
    {
        await dbContext.Database.EnsureDeletedAsync();
        await dbContext.Database.EnsureCreatedAsync();
    });
#endif
}

#endif
app.Run();
