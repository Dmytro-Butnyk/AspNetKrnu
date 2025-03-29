using System.Security.Claims;
using Application.Contracts.Identity;
using Application.DTO.Requests.Account.Queries;
using Domain.Interfaces.DbRepositoryInterfaces;
using Domain.Models.DbModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Application.Handlers.Account;

/// <summary>
/// Handler for LogInQuery
/// </summary>
/// <param name="userRepository"></param>
/// <param name="passwordHasher"></param>
/// <param name="jwtBearerService"></param>
/// <param name="cookieOptions"></param>
/// <param name="httpContextAccessor"></param>
public class LogInQueryHandler(
    IUserRepository userRepository,
    IPasswordHasher<User> passwordHasher, 
    IJwtBearerService jwtBearerService,
    IOptionsMonitor<Application.Options.CookieOptions> cookieOptions,
    IHttpContextAccessor httpContextAccessor,
    IAccountService accountService)
    : IRequestHandler<LogInQuery, Unit>
{
    private readonly Application.Options.CookieOptions _cookieSettings = cookieOptions.CurrentValue;
    
    public async Task<Unit> Handle(LogInQuery request, CancellationToken ct)
    {
        User? user = await accountService.AuthenticateUser(request.Email, request.Password, ct);
        
        if (user is null)
        {
            throw new Exception($"User with {nameof(request.Email)}: {request.Email} was not found");
        }
        
        ClaimsIdentity identity = jwtBearerService.GetIdentity(user);
        string token = jwtBearerService.GetToken(identity);

        var cookieOptions = new CookieOptions
        {
            HttpOnly = _cookieSettings.HttpOnly,
            Secure = _cookieSettings.Secure,
            SameSite = Enum.Parse<SameSiteMode>(_cookieSettings.SameSite),
            Expires = DateTime.UtcNow.AddHours(_cookieSettings.ExpiresInHours)
        };
        
        httpContextAccessor.HttpContext?.Response.Cookies.Append("Token", token, cookieOptions);

        return Unit.Value;
    }
}