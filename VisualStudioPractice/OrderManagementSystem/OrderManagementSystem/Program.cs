
using Asp.Versioning;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi;
using OrderManagementSystem.Data;
using OrderManagementSystem.MiddleWare;
using OrderManagementSystem.Repositories;
using Serilog;

namespace OrderManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/orderservice-.log", rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 7,
                outputTemplate: "{Timestamp:yyyy-MM-dd hh:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
                )
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Host.UseSerilog();
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Order Management API",
                    Version = "v1",
                    Description = "Version 1 - Basic order operations"
                });
                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Order Management API",
                    Version = "v2",
                    Description = "Version 2 - Enhanced responses with metadata"
                });
            });

            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),        // /api/v1/order
                    new HeaderApiVersionReader("X-Version"), // Header: X-Version: 1
                    new QueryStringApiVersionReader("ver")   // ?ver=1
                );
            }).AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    ef =>
                    {
                        ef.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                        ef.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(10),
                            errorNumbersToAdd: null
                        );
                    }));

            builder.Services.AddScoped<IApplicationDbContext>( provider => provider.GetService<ApplicationDbContext>()!);
            builder.Services.AddHealthChecks()
                    .AddDbContextCheck<ApplicationDbContext>("database");

            builder.Services.AddTransient<IOrderRepository, OrderRepository>();

            var app = builder.Build();
            // After var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Order API V1");
                options.SwaggerEndpoint("/swagger/v2/swagger.json", "Order API V2");
            });

            app.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    context.Response.ContentType = "application/json";

                    var result = new
                    {
                        status = report.Status.ToString(),
                        application = "Order Management API",
                        environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
                        checks = report.Entries.Select(e => new
                        {
                            name = e.Key,
                            status = e.Value.Status.ToString(),
                            description = e.Value.Description,
                            error = e.Value.Exception?.Message
                        })
                    };

                    // Set HTTP status code based on health
                    context.Response.StatusCode = report.Status switch
                    {
                        HealthStatus.Healthy => StatusCodes.Status200OK,
                        HealthStatus.Degraded => StatusCodes.Status200OK,
                        HealthStatus.Unhealthy => StatusCodes.Status503ServiceUnavailable,
                        _ => StatusCodes.Status503ServiceUnavailable
                    };

                    await context.Response.WriteAsJsonAsync(result);
                }
            });
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
