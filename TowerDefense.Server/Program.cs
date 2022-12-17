using TowerDefense.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR()
    .AddJsonProtocol(options =>
    {
        options.PayloadSerializerOptions.IncludeFields = true;
    });
var app = builder.Build();

app.MapHub<ChatHub>("/hub");

app.Run();
