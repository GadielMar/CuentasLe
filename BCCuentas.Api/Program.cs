using BC.Shared.Conexion;
using BC.Shared.HandlerException;
using BC.Shared.HandlerSwagger;
using BCCuentas.Application.Contracts;
using BCCuentas.Application.Service;
using BCCuentas.Infrastructure;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using BCCuentas.Api.SwaggerHandler;
using BC.Shared.HandlerJsonSerialized;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddSharedJsonOptions();

// extensiones propias
builder.Services.AddScoped<ICuentasRepository, CuentasRepository>();
builder.Services.AddScoped<ICuentasService, CuentasService>();
builder.Services.AddScoped<IDbConnectionFactory, InformixConnectionFactory>();

builder.Services.AddApiVersioning();
builder.Services.AddSwaggerAndVersioning();
builder.Services.AddSharedExceptionHandler();

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfig>();

builder.Services.AddSwaggerGen();

builder.Services.AddSharedSwagger("BCCuentas.Api.xml", "BCCuentas.Application.xml");
//

var app = builder.Build();

//extensiones propias
app.UseSharedExceptionHandler();
app.UseSharedSwaggerUI();
//

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
