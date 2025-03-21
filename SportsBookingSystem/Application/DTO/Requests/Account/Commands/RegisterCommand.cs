using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.DTO.Requests.Account.Commands;

public class RegisterCommand : IRequest<Unit>
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [MinLength(6)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
    
    public RegisterCommand(){}
}