namespace VehicleInventory.Application.CarModels;

public class CarModelDto
{
    public Guid CarModelId { get; set; }
    
    public string CarName { get; set; }
    
    public decimal CarPrice { get; set; } 
    
    public string PictureUrl { get; set; }
}