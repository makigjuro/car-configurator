using CarConfigurator.Framework.Configuration.Queries;

namespace VehicleInventory.Application.CarItemTypes;

public class GetCarItemTypeQuery : IQuery<List<CarItemTypesDto>>
{
    public GetCarItemTypeQuery()
    {
    }
}
