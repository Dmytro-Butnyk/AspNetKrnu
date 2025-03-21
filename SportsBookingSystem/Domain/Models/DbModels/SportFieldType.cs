using Domain.Models.DbModels.Shared;

namespace Domain.Models.DbModels;

public class SportFieldType : BaseModel
{
    public string Type { get; set; }
    
    public SportFieldType(){}
}