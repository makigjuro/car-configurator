namespace Configurator.Application.Requests;

public class SetCarItemDtoRequest
{
    public Guid CarItemId { get; set; }
    
    public Guid CarItemTypeId { get; set; }
    
    public string CarItemTypeName { get; set; }
    
    public string ItemName { get; set; }
    
    public decimal ItemPrice { get; set; } 
    
    public string PictureUrl { get; set; }
    
    public string Description { get; set; }
}