namespace CommunicationService;

public class LlamaPrompt
{
    public string Model { get; set; }
    public string Prompt { get; set; }
    public bool Stream { get; set; }
}