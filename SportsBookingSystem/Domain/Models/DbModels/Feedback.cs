using Domain.Enums;
using Domain.Models.DbModels.Shared;

namespace Domain.Models.DbModels;

public class Feedback : BaseModel
{
    public User User { get; set; }
    public SportField SportField { get; set; }
    public string Comment { get; set; }
    public Rating Rating { get; set; }
    
    public Feedback(){}
}