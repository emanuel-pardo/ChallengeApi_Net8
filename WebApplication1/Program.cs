using Interfaces;
using Manager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository;
using System;

const string PoliticaCors = "AllowAll";
const string BDname = "SystemStatuses";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBcontext>(options =>
    options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("key") ?? BDname));
builder.Services.AddScoped<IBSManager, BSManager>();
builder.Services.AddScoped<ISystemStatusRepository, SystemStatusRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient();

builder.Services.AddCors(options =>
{   
    options.AddPolicy(PoliticaCors, app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(PoliticaCors);

app.MapControllers();

app.Run();
