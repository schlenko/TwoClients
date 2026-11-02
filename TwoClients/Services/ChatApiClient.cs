using System.Net.Http.Json;
using ChatApp.Shared;

namespace TwoClients.Services;

public class ChatApiClient(HttpClient http)
{
    public Uri HubUrl => new(http.BaseAddress!, ChatRoutes.Hub);

    public async Task<List<ChatMessage>> GetMessagesAsync()
        => await http.GetFromJsonAsync<List<ChatMessage>>(ChatRoutes.Messages) ?? new();

    public async Task<bool> SendAsync(string user, string text)
    {
        var response = await http.PostAsJsonAsync(ChatRoutes.Messages, new SendMessageRequest(user, text));
        return response.IsSuccessStatusCode;
    }
}