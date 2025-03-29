using Application.Contracts.Identity;
using Application.DTO.Requests.Account.Commands;
using Domain.Enums;
using Domain.Models.DbModels;
using MediatR;

namespace Application.Handlers.Account;

public class RegisterCommandHandler(
    IAccountService accountService)
    : IRequestHandler<RegisterCommand, Unit>
{
    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        User? user = await accountService.AuthenticateUser(request.Email, request.Password, cancellationToken);
        
        if (user is not null)
        {
            throw new Exception($"User with {nameof(request.Email)}: {request.Email} already exists");
        }
        
        await accountService.RegisterUser(request.Email, request.Password, cancellationToken);
        
        return Unit.Value;
    }
}