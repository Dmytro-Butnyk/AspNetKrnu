using Data.Repositories.Shared;
using Domain.Interfaces.DbRepositoryInterfaces;
using Domain.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

/// <summary>
/// Repository for getting data directly from the database for the User entity
/// </summary>
/// <param name="context">SportsBookDbContext</param>
public class UserRepository(SportsBookDbContext context)
    : Repository<User>(context),
        IUserRepository
{
    public async Task<User?> GetUserByEmail(string email, CancellationToken ct)
    {
        User? user = await context.Users
            .FirstOrDefaultAsync(x => x.Email == email, ct);
        
        return user ?? null;
    }
}