using Backend.Services;
using Core.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

#region Services
// Используем переменные среды окружения (займусь потом, пока не работает, настраиваю напрямую в AppSettings)
// setx ASPNETCORE_AppSettings_Key "This is my top secret, use your own secret"
// Система -> О программе -> Дополнительные параметры системы
// builder.Configuration.AddEnvironmentVariables(prefix: "Backend_");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDbContext<RestaurantDbContext>()
    .AddUnitOfWork()
    .AddCustomServices()
    .AddCustomSwaggerGen()
    .AddCustomAuthService(builder.Configuration);

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(_ => _.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseDefaultFiles();

app.UseStaticFiles();

app.Run();