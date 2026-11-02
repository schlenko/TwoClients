using ChatApp.Shared;

namespace ChatApp.Server.Services;

public class ChatService : IChatService
{
    private const int MaxMessages = 200;
    private readonly List<ChatMessage> _messages = new();
    private readonly object _lock = new();

    public ChatMessage Add(string user, string text)
    {
        var message = new ChatMessage(user, text, DateTime.UtcNow);
        lock (_lock)
        {
            _messages.Add(message);
            if (_messages.Count > MaxMessages)
                _messages.RemoveAt(0);
        }
        return message;
    }

    public IReadOnlyList<ChatMessage> GetRecent()
    {
        lock (_lock)
        {
            return _messages.ToList();
        }
    }
}