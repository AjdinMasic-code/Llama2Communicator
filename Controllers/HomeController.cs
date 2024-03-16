using System.Diagnostics;
using CommunicationService;
using Microsoft.AspNetCore.Mvc;
using LlamaCommunicator.Models;

namespace LlamaCommunicator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICommunicator _communicator;

    public HomeController(ILogger<HomeController> logger, ICommunicator communicator)
    {
        _logger = logger;
        _communicator = communicator;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<string> ProcessRequest([FromBody] string prompt)
    {
        return await _communicator.MakeRequest(prompt);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}