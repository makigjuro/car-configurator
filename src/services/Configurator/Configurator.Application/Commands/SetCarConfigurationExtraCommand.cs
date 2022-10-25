using System.Windows.Input;
using CarConfigurator.Framework.Configuration.Commands;
using Configurator.Application.Requests;

namespace Configurator.Application.Commands;

public class SetCarConfigurationExtraCommand : CommandBase
{
    public Guid CarBrandId { get; set; }
    
    public Guid CarConfigurationId { get; set; }
    
    public SetCarItemDtoRequest CarExtra { get; set; }
}