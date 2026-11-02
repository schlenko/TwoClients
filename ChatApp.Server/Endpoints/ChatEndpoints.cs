using ChatApp.Server.Hubs;
using ChatApp.Server.Services;
using ChatApp.Shared;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Server.Endpoints;

public static class ChatEndpoints
{
    public static void MapChatEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(ChatRoutes.Messages);

        group.MapGet("", (IChatService chat) => Results.Ok(chat.GetRecent()));

        group.MapPost("", async (
            SendMessageRequest request,
            IChatService chat,
            IHubContext<ChatHub> hub) =>
        {
            if (string.IsNullOrWhiteSpace(request.User) || string.IsNullOrWhiteSpace(request.Text))
                return Results.BadRequest("User and text are required.");

            var message = chat.Add(request.User.Trim(), request.Text.Trim());
            await hub.Clients.All.SendAsync(ChatRoutes.ReceiveMethod, message);
            return Results.Ok(message);
        });
    }
}