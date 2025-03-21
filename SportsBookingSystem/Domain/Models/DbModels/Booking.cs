using Domain.Enums;
using Domain.Models.DbModels.Shared;

namespace Domain.Models.DbModels;

public class Booking : BaseModel
{
    public User User { get; set; }
    public SportField SportField { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public EntityStatus Status { get; set; }
    
    public Booking(){}  
}