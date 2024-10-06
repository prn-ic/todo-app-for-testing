using Ocelot.DependencyInjection;
using Ocelot.Middleware;

string localAllowSpecificOrigins = "lan_allow_specific_origins";

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("ocelot.Development.json")
    .Build();

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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOcelot();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(localAllowSpecificOrigins);
await app.UseOcelot();

app.Run();
