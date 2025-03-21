using Domain.Enums;
using Domain.Models.DbModels.Shared;

namespace Domain.Models.DbModels;

public class SportField : BaseModel
{
    public string Name { get; set; }
    public SportFieldType Type { get; set; }
    public string Location { get; set; }
    public string PhotoUrl { get; set; }
    public EntityStatus Status { get; set; }

    public SportField(){}
}