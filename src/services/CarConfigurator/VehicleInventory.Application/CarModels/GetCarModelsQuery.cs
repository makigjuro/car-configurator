using CarConfigurator.Framework.Configuration.Queries;

namespace VehicleInventory.Application.CarModels;

public class GetCarModelsQuery : IQuery<List<CarModelDto>>
{
    public Guid CarBrandId { get; }

    public GetCarModelsQuery(Guid carBrandId)
    {
        CarBrandId = carBrandId;
    }
}
