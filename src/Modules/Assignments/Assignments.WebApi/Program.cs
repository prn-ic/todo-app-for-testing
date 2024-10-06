using System.Reflection;
using Assignments.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        string localAllowSpecificOrigins = "lan_allow_specific_origins";

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder
            .Services.AddControllers()
            .AddApplicationPart(Assembly.Load("Assignments.Controllers"))
            .AddControllersAsServices();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(Assembly.Load("Assignments.Application"));
        builder.Services.AddSqliteConnection().AddPersistanseLayer();
        builder.Services.AddApiVersioning(cfg =>
        {
            cfg.ApiVersionReader = new HeaderApiVersionReader("api-version");
            cfg.DefaultApiVersion = new ApiVersion(1, 0);
            cfg.AssumeDefaultVersionWhenUnspecified = true;
        });
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.Load("Assignments.Application"));
        });
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(
                localAllowSpecificOrigins,
                policy =>
                {
                    policy
                        //policy.WithOrigins("https://192.168.0.101:9000", "https://localhost:9000", "https://localhost")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed((hosts) => true);
                }
            );
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors(localAllowSpecificOrigins);

        app.MapControllers();
        app.Run();
    }
}
