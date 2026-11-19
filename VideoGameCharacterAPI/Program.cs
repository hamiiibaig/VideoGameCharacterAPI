
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VideoGameCharacterAPI.data;
using VideoGameCharacterAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Configure OpenAPI
builder.Services.AddOpenApi();

// Connect SQL Server Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Register Service
builder.Services.AddScoped<IVideoGameCharacterService, VideoGameCharacterServices>();

var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
