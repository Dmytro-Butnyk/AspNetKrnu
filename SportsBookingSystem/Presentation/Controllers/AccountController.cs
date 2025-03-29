using System.Diagnostics;
using Application.Contracts.Identity;
using Application.DTO.Requests.Account.Commands;
using Application.DTO.Requests.Account.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportsBookingSystem.Models;

namespace SportsBookingSystem.Controllers;

public class AccountController(
    ILogger<AccountController> logger,
    IMediator mediator) : Controller
{
    public IActionResult Authorization()
    {
        return View();
    }

    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Authorization(LogInQuery query)
    {
        if (!ModelState.IsValid)
        {
            return View(query); 
        }

        try
        {
            await mediator.Send(query);
            return RedirectToAction("Registration", "Account");
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while logging in");
            ModelState.AddModelError("", "Invalid email or password");
            return View(query);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Registration(RegisterCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command); 
        }
        
        try
        {
            await mediator.Send(command);
            return RedirectToAction("Authorization", "Account");
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while registering");
            ModelState.AddModelError("", "Email already exists");
            return View(command);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}