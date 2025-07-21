using Microsoft.EntityFrameworkCore;
using SimpleApiProject.Data;
using SimpleApiProject.Repositories;
using SimpleApiProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Connection string'i oku
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DbContext'i baðla
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        db.Database.CanConnect();
        Console.WriteLine(" PostgreSQL baðlantýsý baþarýlý!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($" Veritabaný baðlantý hatasý: {ex.Message}");
    }
}

app.Run();
