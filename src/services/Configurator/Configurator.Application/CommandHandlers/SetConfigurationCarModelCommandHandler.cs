using CarConfigurator.Framework.Configuration.Commands;
using CarConfigurator.Framework.Database;
using Configurator.Application.Commands;
using Configurator.Domain.Entities;
using Configurator.Domain.Repositories;
using MediatR;

namespace Configurator.Application.CommandHandlers;

public class SetConfigurationCarModelCommandHandler : ICommandHandler<SetConfigurationCarModelCommand>
{
    private readonly IConfigurationsRepository _configurationsRepository;
    private readonly IUnitOfWork _unitOfWork;


    public SetConfigurationCarModelCommandHandler(IConfigurationsRepository configurationsRepository, IUnitOfWork unitOfWork)
    {
        _configurationsRepository = configurationsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(SetConfigurationCarModelCommand command, CancellationToken cancellationToken)
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

        carConfiguration.SetCarModel(new Model()
        {
            Id = command.CarModelDto.CarModelId,
            Name = command.CarModelDto.CarName,
            Price = command.CarModelDto.CarPrice
        });
        
        await this._unitOfWork.CommitAsync(cancellationToken);
        
        return Unit.Value;
    }
}