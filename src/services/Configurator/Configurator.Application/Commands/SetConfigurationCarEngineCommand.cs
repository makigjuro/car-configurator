using CarConfigurator.Framework.Configuration.Commands;
using Configurator.Application.Requests;

namespace Configurator.Application.Commands;

public class SetConfigurationCarEngineCommand : CommandBase
{
    public Guid CarBrandId { get; set; }
    
    public Guid CarConfigurationId { get; set; }
    
    public SetCarItemDtoRequest CarEngine { get; set; }
}