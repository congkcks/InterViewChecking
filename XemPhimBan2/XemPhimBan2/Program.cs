using Microsoft.EntityFrameworkCore;
using XemPhimBan2.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RapchieuphimContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.Parse("8.0.39-mysql")
    ));

// ✅ Thêm CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ✅ Bật CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();
app.Run();
