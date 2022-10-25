namespace Configurator.Application.Requests;

public class SetConfigurationRimsRequest
{
    public Guid CarBrandId { get; set; }
    
    public Guid CarConfigurationId { get; set; }
    
    public SetCarItemDtoRequest CarRims { get; set; }

}