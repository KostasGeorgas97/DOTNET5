global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading.Tasks;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Http;
global using System.Net.Http;
global using DOTNET5.Controllers;
global using Microsoft.EntityFrameworkCore;
global using DOTNET5.Models;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.EntityFrameworkCore.Storage.Internal;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.HttpsPolicy;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Newtonsoft.Json;
global using DOTNET5.Context;
global using University = DOTNET5.Models.Universities;

var builder = WebApplication.CreateBuilder(args);

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

app.Run();
