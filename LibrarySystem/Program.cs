using AutoMapper;
using LibraryApi.helper;
using LibraryApi.Models;
using LibraryApi.Models.services;
using LibraryApi.services.category;
using LibraryApi.services.detailsreceipt;
using LibraryApi.services.printer;
using LibraryApi.services.receipt;
using LibraryModel;
using LibraryModel.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);

// Add the memory cache services.
//Without this got this error
//Unable to resolve service for type 'StudentApi.Models.AppDbContext' while attempting to activate 'StudentApi.StudentsController'.
builder.Services.AddDbContext<LibraryDbContext>(opt => opt.UseInMemoryDatabase("LibraryDb"));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategeryRepository>();
builder.Services.AddScoped<IReceiptRepository, ReceiptRepository>();
builder.Services.AddScoped<IDetailsReceiptRepository, DetailsReceiptRepository>();
builder.Services.AddScoped<IPrinterRepository, PrinterRepository>();

// enable core origine
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://127.0.0.1:8081/"
                                              );
                      });
});

// Add services to the container.

builder.Services.AddControllers();

// this is the error without AddControllersWithViews 
//  System.Text.Json.JsonException: A possible object cycle was detected.
//  This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32.
//  Consider using ReferenceHandler.Preserve on JsonSerializerOptions to support cycles.
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
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
app.UseCors(MyAllowSpecificOrigins);


app.MapControllers();

app.Run();
