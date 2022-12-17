using TowerDefense.Server;
using TowerDefense.Server.Models.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR().AddNewtonsoftJsonProtocol();
builder.Services.AddSingleton<EnemyService>();
builder.Services.AddSingleton<IEnemyService>(x => new EnemyServiceProxy(x.GetRequiredService<EnemyService>(), "water"));

var app = builder.Build();

app.MapHub<ChatHub>("/hub");

app.Run();
