using ChatApp.Shared;

namespace ChatApp.Server.Services;

public interface IChatService
{
    ChatMessage Add(string user, string text);
    IReadOnlyList<ChatMessage> GetRecent();
}