using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CeuDeGraos.Models;
using CeuDeGraos.Data;

namespace CeuDeGraos.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BancoContext _dbContext;

    public HomeController(ILogger<HomeController> logger, BancoContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {

        return View();
    }

    public IActionResult Formulario()
    {
        return View();
    }
    

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

     public IActionResult Cookie()
    {
        return View();
    }

    public IActionResult History()
    {
        return View();
    }

    public IActionResult Products()
    {
        return View();
    }

     public IActionResult TermsOfUse()
    {
        return View();
    }

    public IActionResult PrivacyPolicy()
    {
        return View();
    }

    public IActionResult PrivacyCookies()
    {
        return View();
    }

    public IActionResult ConfirmacaoCadastro()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
