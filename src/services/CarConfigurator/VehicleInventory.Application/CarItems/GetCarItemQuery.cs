using CarConfigurator.Framework.Configuration.Queries;

namespace VehicleInventory.Application.CarItems;

public class GetCarItemQuery : IQuery<List<CarItemDto>>
{
    public Guid CarItemTypeId { get; }
    public Guid CarModelId { get; }

    public GetCarItemQuery(Guid carItemTypeId, Guid carModelId)
    {
        CarItemTypeId = carItemTypeId;
        CarModelId = carModelId;
    }
}
