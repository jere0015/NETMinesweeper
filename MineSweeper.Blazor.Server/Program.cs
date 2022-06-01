using MineSweeper.Game;
using MineSweeper.Blazor.Server.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddSingleton<UserAccountService>();

if(builder.Environment.IsDevelopment())
{
    // Use the game engine library
    builder.Services.AddSingleton<IGameFactory, GameFactory>();
    // Use memory repository
    builder.Services.AddSingleton<IRepository<Score>, MemoryRepository<Score>>();
}
else
{
    // Use proxy / client to communicate with game
    builder.Services.AddSingleton<IGameFactory, GameProxyFactory>();

    //TODO: Use database repository
    builder.Services.AddSingleton<IRepository<Score>, MemoryRepository<Score>>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Seed some score data
    var repo = app.Services.GetService<IRepository<Score>>();

    if(repo != null)
    {
        repo.Create(new Score { Holder = "Person1" });
        repo.Create(new Score { Holder = "Person2" });
        repo.Create(new Score { Holder = "Person3" });
        repo.Create(new Score { Holder = "Person4" });
        repo.Create(new Score { Holder = "Person5" });
    }
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
