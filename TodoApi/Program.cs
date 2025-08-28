using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Interfaces;
using TodoApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

// Thêm CORS service - ĐÚNG
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// QUAN TRỌNG: THỨ TỰ MIDDLEWARE PHẢI ĐÚNG
// 1. CORS phải được gọi TRƯỚC các middleware khác
app.UseCors("AllowAngularApp"); // ← ĐẶT Ở ĐẦU TIÊN

// 2. Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 3. HTTPS Redirection
app.UseHttpsRedirection();

// 4. Authorization
app.UseAuthorization();

// 5. Map controllers
app.MapControllers();

// Redirect root to Swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();