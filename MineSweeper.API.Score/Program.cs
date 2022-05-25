using Microsoft.EntityFrameworkCore;
using MineSweeper.API.Score.Context;
using MineSweeper.Game;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ScoreContext>(opt =>
            opt.UseSqlServer(builder.Configuration.GetConnectionString("MineSweeperConn")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
{
    // Use memory repository
    builder.Services.AddSingleton<IRepository<Score>, MemoryRepository<Score>>();
}

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
