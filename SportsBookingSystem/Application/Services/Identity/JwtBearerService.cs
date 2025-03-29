using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Contracts.Identity;
using Application.Options;
using Domain.Models.DbModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.Identity;

public class JwtBearerService(IOptions<JwtOptions> jwtOptions)
    : IJwtBearerService
{
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;
    
    public ClaimsIdentity GetIdentity(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
            new(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
        };

        ClaimsIdentity identity = new(claims, "Token",
            ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

        return identity;
    }
    
    public string GetToken(ClaimsIdentity identity)
    {
        DateTime timeNow = DateTime.UtcNow;
        JwtSecurityToken jwt = new JwtSecurityToken(
            issuer: _jwtOptions.ISSUER,
            audience: _jwtOptions.AUDIENCE,
            notBefore: timeNow,
            claims: identity.Claims,
            expires: timeNow.Add(TimeSpan.FromDays(_jwtOptions.LIFETIME)),
            signingCredentials: new SigningCredentials(_jwtOptions.GetKey(), SecurityAlgorithms.HmacSha256)
        );
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}