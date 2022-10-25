namespace Configurator.Application.Requests;

public class SetConfigurationCarModelRequest
{
    public Guid CarBrandId { get; set; }
    
    public Guid CarConfigurationId { get; set; }
    
    public SetCarModelDto CarModel { get; set; }
}

public class SetCarModelDto
{
    public Guid CarModelId { get; set; }
    
    public string CarName { get; set; }
    
    public decimal CarPrice { get; set; } 
    
    public string PictureUrl { get; set; }
}