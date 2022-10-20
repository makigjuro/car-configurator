using CarConfigurator.Framework.Configuration.Queries;
using VehicleInventory.Domain.CarItems;
using VehicleInventory.Domain.CarItemTypes;
using VehicleInventory.Domain.CarModels;

namespace VehicleInventory.Application.CarItems;

internal sealed class GetCarItemQueryHandler : IQueryHandler<GetCarItemQuery, List<CarItemDto>>
{
    private readonly ICarItemsRepository _carItemsRepository;

    internal GetCarItemQueryHandler(ICarItemsRepository carItemsRepository)
    {
        _carItemsRepository = carItemsRepository;
    }
    
    public async Task<List<CarItemDto>> Handle(GetCarItemQuery request, CancellationToken cancellationToken)
    {
        var carItems = await _carItemsRepository.GetAllCarItemsPerCarModelAndCarItemType(
            request.CarModelId, request.CarItemTypeId);

        return carItems.Select(x => new CarItemDto()
        {
            CarItemId = x.Id,
            ItemName = x.Name,
            ItemPrice = x.Price.Value,
            Description = x.Description,
            PictureUrl = x.PictureUri
        }).ToList();
    }
}
