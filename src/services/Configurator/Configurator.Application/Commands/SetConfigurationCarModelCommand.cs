using CarConfigurator.Framework.Configuration.Commands;
using Configurator.Application.Requests;

namespace Configurator.Application.Commands;

public class SetConfigurationCarModelCommand : CommandBase
{
    public Guid CarBrandId { get; set; }
    
    public Guid CarConfigurationId { get; set; }
    
    public SetCarModelDto CarModelDto { get; set; }
}