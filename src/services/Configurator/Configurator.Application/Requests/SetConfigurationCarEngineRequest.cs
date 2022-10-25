namespace Configurator.Application.Requests;

public class SetConfigurationCarEngineRequest
{
    public Guid CarBrandId { get; set; }
    
    public Guid CarConfigurationId { get; set; }
    
    public SetCarItemDtoRequest CarEngine { get; set; }
}