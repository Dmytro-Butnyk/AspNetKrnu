using Application.Contracts.Identity;
using Domain.Enums;
using Domain.Interfaces.DbRepositoryInterfaces;
using Domain.Models.DbModels;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Identity;

public class AccountService(
    IUserRepository userRepository,
    IPasswordHasher<User> passwordHasher) : IAccountService
{
    public async Task<User?> AuthenticateUser(string email, string password, CancellationToken ct)
    {
        User? user = await userRepository.GetUserByEmail(email, ct);

        if (user is null)
        {
            return null;
        }

        PasswordVerificationResult verificationResult =
            passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        
        return verificationResult == PasswordVerificationResult.Failed ? null : user;
    }
    
    public async Task RegisterUser(string email, string password, CancellationToken ct)
    {
        User user = new()
        {
            Email = email,
            PasswordHash = passwordHasher.HashPassword(null!, password),
            Role = UserRole.User
        };
        
        await userRepository.AddAsync(user, ct);
    }
}