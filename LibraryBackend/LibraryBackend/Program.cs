using AutoMapper;
using FluentValidation.AspNetCore;
using LibraryBackend.DTO;
using LibraryBackend.Models;
using LibraryBackend.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(fv=>
{
    //fv.DisableDataAnnotationsValidation = true;
    fv.RegisterValidatorsFromAssemblyContaining<Program>();
});
builder.Services.AddDbContext<LibraryContext>(opt =>
    opt.UseInMemoryDatabase("Library1"));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.RequestMethod |
    HttpLoggingFields.RequestQuery |
    HttpLoggingFields.RequestHeaders |
    HttpLoggingFields.RequestBody;
    options.RequestBodyLogLimit = 4096;
});

//var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookBaseDto>());
var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        // using static System.Net.Mime.MediaTypeNames;
        context.Response.ContentType = Text.Plain;

        var exceptionHandlerPathFeature =
            context.Features.Get<IExceptionHandlerPathFeature>();
        if(exceptionHandlerPathFeature?.Error is not null)
        {
            string message = string.IsNullOrEmpty(exceptionHandlerPathFeature?.Error.Message) ?
            "": $": {exceptionHandlerPathFeature?.Error.Message}";
            await context.Response.WriteAsync(
                $"An {exceptionHandlerPathFeature?.Error.GetType()} was thrown {message}\nPath: {exceptionHandlerPathFeature?.Path}");
        }
    });
});


app.UseHttpsRedirection();

app.UseHttpLogging();

app.UseAuthorization();

app.MapControllers();

app.Run();






