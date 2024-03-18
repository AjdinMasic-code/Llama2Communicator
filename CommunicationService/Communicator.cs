using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace CommunicationService;

public class Communicator : ICommunicator
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configurationManager;

    public Communicator(IHttpClientFactory httpFactory, IConfiguration configurationManager)
    {
        _httpClient = httpFactory.CreateClient("ollama");
        _configurationManager = configurationManager;
    }
    public async Task<string> MakeRequest(string prompt)
    {
        var newPrompt = new LlamaPrompt()
        {
            Model = _configurationManager.GetValue<string>("ModelSettings:Model") ?? "",
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