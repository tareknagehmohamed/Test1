using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Runtime.InteropServices;
using Test1.Data;
using Test1.Dtos;
using Test1.Models;
using Test1.Reposetories;
using Test1.Services;
using MudBlazor.Services;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NewsConetext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped(sp=>new HttpClient { BaseAddress=new Uri("http://localhost:50447/") });

builder.Services.AddScoped<Irepo<Category>,Mainrepo<Category>>();
builder.Services.AddScoped<Imainser<Category>, Mainser<Category>>();
builder.Services.AddScoped<Irepo<News>, Mainrepo<News>>();
builder.Services.AddScoped<Imainser<News>, Mainser<News>>();
builder.Services.AddScoped<Irepo<Imagedtos>, Mainrepo<Imagedtos>>();
builder.Services.AddScoped<Imainser<Imagedtos>, Mainser<Imagedtos>>();
builder.Services.AddScoped<Irepo<Registerlogin>, Mainrepo<Registerlogin>>();
builder.Services.AddScoped<Imainser<Registerlogin>, Mainser<Registerlogin>>();
builder.Services.AddScoped<Irepo<Groupclass>, Mainrepo<Groupclass>>();
builder.Services.AddScoped<Imainser<Groupclass>, Mainser<Groupclass>>();
builder.Services.AddScoped<Irepo<Rating>, Mainrepo<Rating>>();
builder.Services.AddScoped<Imainser<Rating>, Mainser<Rating>>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllers();
app.Run();
