using MediatR;

namespace Application.DTO.Requests.Account.Queries;

public class LogInQuery : IRequest<Unit>
{
    public string Email { get; set; }
    public string Password { get; set; }
    
    public LogInQuery(){}
}