using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.DTO.Requests.Account.Queries;

public class LogInQuery : IRequest<Unit>
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [MinLength(6)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    public LogInQuery(){}
}