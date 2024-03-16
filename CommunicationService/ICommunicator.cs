namespace CommunicationService;

public interface ICommunicator
{
    Task<string> MakeRequest(string prompt);
}