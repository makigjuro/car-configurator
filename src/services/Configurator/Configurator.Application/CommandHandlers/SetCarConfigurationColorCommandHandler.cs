using CarConfigurator.Framework.Configuration.Commands;
using CarConfigurator.Framework.Database;
using Configurator.Application.Commands;
using Configurator.Domain.Entities;
using Configurator.Domain.Repositories;
using MediatR;

namespace Configurator.Application.CommandHandlers;

public class SetCarConfigurationColorCommandHandler : ICommandHandler<SetConfigurationCarColorCommand>
{
    private readonly IConfigurationsRepository _configurationsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SetCarConfigurationColorCommandHandler(IConfigurationsRepository configurationsRepository, IUnitOfWork unitOfWork)
    {
        _configurationsRepository = configurationsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(SetConfigurationCarColorCommand command, CancellationToken cancellationToken)
    {
        var carConfiguration = await _configurationsRepository.GetByIdAsync(command.CarConfigurationId);

        if (carConfiguration == null)
        {
            carConfiguration = await _configurationsRepository.AddAsync(new CarConfiguration()
            {
                Id = command.CarConfigurationId,
                BrandId = command.CarConfigurationId,
                Name = "My Custom Configuration"
            });
        }

        carConfiguration.SetColor(new CarColor()
        {
            Id = command.CarColor.CarItemId,
            Name = command.CarColor.ItemName,
            Price = command.CarColor.ItemPrice

        });
        
        await this._unitOfWork.CommitAsync(cancellationToken);
        
        return Unit.Value;
    }
}
