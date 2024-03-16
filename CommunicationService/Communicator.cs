using System.Text;
using System.Text.Json;

namespace CommunicationService;

public class Communicator : ICommunicator
{
    private readonly HttpClient _httpClient;

    public Communicator(IHttpClientFactory httpFactory)
    {
        _httpClient = httpFactory.CreateClient("llama2-uncensored");
    }
    public async Task<string> MakeRequest(string prompt)
    {
        var newPrompt = new LlamaPrompt()
        {
            Model = "llama2-uncensored",
            Prompt = prompt,
            Stream = false
        };

        var json = JsonSerializer.Serialize(newPrompt);

        var jsonStringContent = new StringContent(json, Encoding.UTF8, "application/json");
        try
        {
            var response = await _httpClient.PostAsync("generate", jsonStringContent);

            response.EnsureSuccessStatusCode();
            var message = await response.Content.ReadAsStringAsync();
            var deserializedResponse = JsonSerializer.Deserialize<LlamaResponse>(message);
            return deserializedResponse.Response;
        }
        catch (Exception ex)
        {
            return $"Error: {ex.InnerException}";
        }
    }
}