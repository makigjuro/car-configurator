using CarConfigurator.Framework.Configuration.Queries;
using VehicleInventory.Domain.CarItemTypes;

namespace VehicleInventory.Application.CarItemTypes;

internal sealed class GetCarItemTypeQueryHandler : IQueryHandler<GetCarItemTypeQuery, List<CarItemTypesDto>>
{
    private readonly ICarItemTypesRepository _repository;

    internal GetCarItemTypeQueryHandler(ICarItemTypesRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<CarItemTypesDto>> Handle(GetCarItemTypeQuery request, CancellationToken cancellationToken)
    {
        var models = await _repository.GetAllCarItemTypes();

        return models.Select(x => new CarItemTypesDto()
        {
            CarItemTypeId = x.Id,
            TypeName = x.Name
        }).ToList();
    }
}
