using System.Diagnostics;
using Application.DTO.Requests.Account.Commands;
using Application.DTO.Requests.Account.Queries;
using Microsoft.AspNetCore.Mvc;
using SportsBookingSystem.Models;

namespace SportsBookingSystem.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    public IActionResult Authorization()
    {
        return View();
    }

    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> LogIn(LogInQuery query)
    {
        return View();
    }
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}