using Microsoft.EntityFrameworkCore;
using RegistrarSuite.Data.DataContext;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Reflection.Metadata;
using RegistrarSuite.Services;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source =/app.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder => { builder.RegisterModule(new AutoFacConfiguration()); });
var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Registrar Suite API V1");
    });
}

app.UseHttpsRedirection();
//app.UseAutofac();

app.UseAuthorization();

app.MapControllers();

app.Run();
