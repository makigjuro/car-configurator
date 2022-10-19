using CarConfigurator.Framework.Configuration.Queries;
using VehicleInventory.Domain.CarBrands;
using VehicleInventory.Domain.CarModels;

namespace VehicleInventory.Application.CarModels;

internal sealed class GetCarModelsQueryHandler : IQueryHandler<GetCarModelsQuery, List<CarModelDto>>
{
    private readonly ICarModelsRepository _repository;

    internal GetCarModelsQueryHandler(ICarModelsRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<CarModelDto>> Handle(GetCarModelsQuery request, CancellationToken cancellationToken)
    {
        var models = await _repository.GetAllCarModelsForBrand(request.CarBrandId);
        return models.Select(x => new CarModelDto()
        {
            CarModelId = x.Id,
            CarName = x.Name,
            CarPrice = x.Price.Value,
            PictureUrl = x.PictureUri
        }).ToList();
    }
}
