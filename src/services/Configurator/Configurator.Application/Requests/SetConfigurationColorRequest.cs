namespace Configurator.Application.Requests;

public class SetConfigurationColorRequest
{
    public Guid CarBrandId { get; set; }
    
    public Guid CarConfigurationId { get; set; }
    
    public SetCarItemDtoRequest CarColor { get; set; }
}