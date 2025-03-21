using Data.Repositories.Shared;
using Domain.Interfaces.DbRepositoryInterfaces;
using Domain.Models.DbModels;

namespace Data.Repositories;

/// <summary>
/// Repository for getting data directly from the database for the SportField entity
/// </summary>
/// <param name="context">SportsBookDbContext</param>
public class SportFieldRepository(SportsBookDbContext context)
    : Repository<SportField>(context),
        ISportFieldRepository
{
    
}