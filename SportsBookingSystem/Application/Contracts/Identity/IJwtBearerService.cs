using System.Security.Claims;
using Domain.Models.DbModels;

namespace Application.Contracts.Identity;

public interface IJwtBearerService
{
    ClaimsIdentity GetIdentity(User user);
    string GetToken(ClaimsIdentity identity);
}