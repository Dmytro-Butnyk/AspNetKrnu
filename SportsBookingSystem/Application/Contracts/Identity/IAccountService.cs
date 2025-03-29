using Domain.Models.DbModels;

namespace Application.Contracts.Identity;

public interface IAccountService
{
    Task<User?> AuthenticateUser (string email, string password, CancellationToken ct);
    Task RegisterUser(string email, string password, CancellationToken ct);
}