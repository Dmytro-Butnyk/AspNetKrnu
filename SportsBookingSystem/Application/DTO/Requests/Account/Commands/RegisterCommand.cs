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
    [MaxLength(50)]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$", 
        ErrorMessage = "Password must contain at least 1 uppercase letter, 1 number, and 1 special character")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
    
    public RegisterCommand(){}
}