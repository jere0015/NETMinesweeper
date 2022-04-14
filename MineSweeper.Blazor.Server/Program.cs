using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MineSweeper.Game;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<IConfigFactory, ConfigFactory>();
builder.Services.AddScoped<IBoardFactory, BoardFactory>();
builder.Services.AddScoped<ITileFactory, TileFactory>();
builder.Services.AddScoped<IStateFactory, StateFactory>();
builder.Services.AddScoped<IGameFactory, GameFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
