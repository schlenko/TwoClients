namespace ChatApp.Shared;

public record ChatMessage(string User, string Text, DateTime SentAtUtc);

public record SendMessageRequest(string User, string Text);

public static class ChatRoutes
{
    public const string Hub = "/chathub";
    public const string Messages = "/api/messages";
    public const string ReceiveMethod = "ReceiveMessage";
}