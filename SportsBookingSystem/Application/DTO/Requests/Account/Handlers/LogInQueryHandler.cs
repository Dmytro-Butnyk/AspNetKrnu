using Application.DTO.Requests.Account.Queries;
using Domain.Interfaces.DbRepositoryInterfaces;
using Domain.Models.DbModels;
using MediatR;

namespace Application.DTO.Requests.Account.Handlers;

public class LogInQueryHandler
    (IUserRepository userRepository)
    : IRequestHandler<LogInQuery, Unit>
{
    public async Task<Unit> Handle(LogInQuery request, CancellationToken cancellationToken)
    {
        
    }
    
    private async Task<User> AuthenticateUser(string login, string password)
    {
    }
}