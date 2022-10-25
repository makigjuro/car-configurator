namespace Configurator.Application.Requests;

public class OrderRequest
{
    public Guid CarBrandId { get; set; }

    public Guid CarConfigurationId { get; set; }
}