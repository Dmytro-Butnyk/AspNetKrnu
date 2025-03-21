using Domain.Enums;
using Domain.Models.DbModels.Shared;

namespace Domain.Models.DbModels;

public class User : BaseModel
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; }
    
    public User(){}
}