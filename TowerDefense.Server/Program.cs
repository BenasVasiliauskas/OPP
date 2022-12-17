using TowerDefense.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR().AddNewtonsoftJsonProtocol();
var app = builder.Build();

app.MapHub<ChatHub>("/hub");

app.Run();
