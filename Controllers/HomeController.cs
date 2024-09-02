using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KeyVaultTestAzure.Models;
using Azure.Security.KeyVault.Secrets;


namespace KeyVaultTestAzure.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SecretClient _secretClient;


    public HomeController(ILogger<HomeController> logger, SecretClient SecretClient)
    {
        _logger = logger;
        _secretClient = SecretClient;
    }

    public IActionResult Index()
    {
        KeyVaultSecret secret = _secretClient.GetSecret("SDW");
            ViewBag.SecretValue = secret.Value;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
