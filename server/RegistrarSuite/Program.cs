using Microsoft.EntityFrameworkCore;
using RegistrarSuite.Data.DataContext;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using RegistrarSuite.Services;
using AutoMapper;
using RegistrarSuite.Data.Seed;
using NLog.Web;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var path = $"{Directory.GetCurrentDirectory()}\\app.db";
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Data Source ={path}"));
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source =/app.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder => { builder.RegisterModule(new AutoFacConfiguration()); });
var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<DataSeedInitializations>();

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder.AddNLogWeb("nlog.config");  
});

var corePolicy = "_CustomCorePolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corePolicy,
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Registrar Suite API V1");
    });
    app.SeedData();
}

app.UseHttpsRedirection();

app.UseCors(corePolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
