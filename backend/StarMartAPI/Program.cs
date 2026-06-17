using Microsoft.EntityFrameworkCore;
using StarMartAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StarMartContext>(options =>
  options.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options => {
  options.AddPolicy("AllowAll", policy =>
    policy.WithOrigins(
        "https://starmartmall.vn",
        "https://www.starmartmall.vn",
        "http://starmartmall.vn",
        "http://www.starmartmall.vn",
        "http://localhost:5500",     
        "http://127.0.0.1:5500"
      ).AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => {
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "StarMart API v1");
  c.RoutePrefix = "swagger";
});

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();
