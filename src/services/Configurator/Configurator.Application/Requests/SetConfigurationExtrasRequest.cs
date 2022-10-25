namespace Configurator.Application.Requests;

public class SetConfigurationExtrasRequest
{
    public SetConfigurationExtrasRequest()
    {
        CarExtras = new List<SetCarItemDtoRequest>();
    }
    
    public Guid CarBrandId { get; set; }

    public Guid CarConfigurationId { get; set; }

    public List<SetCarItemDtoRequest> CarExtras { get; set; }
}