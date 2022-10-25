namespace Configurator.Application.Requests;

public class SetConfigurationExtrasRequest
{
    public SetConfigurationExtrasRequest()
    {
    }
    
    public Guid CarBrandId { get; set; }

    public Guid CarConfigurationId { get; set; }

    public SetCarItemDtoRequest CarExtras { get; set; }
}