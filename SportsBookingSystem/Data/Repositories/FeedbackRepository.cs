using Data.Repositories.Shared;
using Domain.Interfaces.DbRepositoryInterfaces;
using Domain.Models.DbModels;

namespace Data.Repositories;

/// <summary>
/// Repository for getting data directly from the database for the Feedback entity
/// </summary>
/// <param name="context">SportsBookDbContext</param>
public class FeedbackRepository(SportsBookDbContext context)
    : Repository<Feedback>(context),
        IFeedbackRepository
{
}