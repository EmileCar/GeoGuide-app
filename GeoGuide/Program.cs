﻿using GeoGuide.Domain;
using GeoGuide.Repositories;
using GeoGuide.Repositories.Interfaces;
using GeoGuide.Services;
using GeoGuide.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GeoGuide API",
        Version = "version 1",
        Description = "An API to perform GeoGuide operations",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Carone",
            Email = "caron.emile@telenet.be",
            Url = new Uri("https://vives.be"),
        },
        License = new OpenApiLicense
        {
            Name = "Employee API LICX",
            Url = new Uri("https://example.com/license"),
        }
    });
});


// Lees de connectiestring uit de configuratie
var connectionString = builder.Configuration.GetConnectionString("MongoDBConnection");

// Registreer de MongoDB-client als een singleton service
builder.Services.AddSingleton<IMongoClient>(new MongoClient(connectionString));

// add Automapper
//your code
//DI
builder.Services.AddTransient<IDAO<Country>, CountryDAO>();
builder.Services.AddTransient<IService<Country>, CountryService>();
builder.Services.AddTransient<IDAO<Region>, RegionDAO>();
builder.Services.AddTransient<IService<Region>, RegionService>();
builder.Services.AddTransient<IDAO<CoverageType>, CoverageTypeDAO>();
builder.Services.AddTransient<IService<CoverageType>, CoverageTypeService>();
builder.Services.AddTransient<ApiDAO>();
builder.Services.AddTransient<ApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var swaggerOptions = new GeoGuide.Options.SwaggerOptions();
builder.Configuration.GetSection(nameof(GeoGuide.Options.SwaggerOptions)).Bind(swaggerOptions);
// Enable middleware to serve generated Swagger as a JSON endpoint.
//RouteTemplate legt het path vast waar de JSON‐file wordt aangemaakt
app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });
//// By default, your Swagger UI loads up under / swagger /.If you want to change this, it's thankfully very straight‐forward. Simply set the RoutePrefix option in your call to app.UseSwaggerUI in Program.cs:
app.UseSwaggerUI(option =>
{
    option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
});
app.UseSwagger();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "country",
		pattern: "Country/Detail/{countryCode}",
		defaults: new { controller = "Country", action = "Detail" });
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
