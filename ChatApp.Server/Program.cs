using ChatApp.Server.Endpoints;
using ChatApp.Server.Hubs;
using ChatApp.Server.Services;
using ChatApp.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddSingleton<IChatService, ChatService>();

var app = builder.Build();

app.MapChatEndpoints();
app.MapHub<ChatHub>(ChatRoutes.Hub);

app.Run();