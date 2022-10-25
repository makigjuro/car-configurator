namespace Configurator.Application.Requests;

public class SetConfigurationInteriorRequest
{
    public Guid CarBrandId { get; set; }
    
    public Guid CarConfigurationId { get; set; }
    
    public SetCarItemDtoRequest CarInterior { get; set; }

}