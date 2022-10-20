using CarConfigurator.Framework.Configuration.Queries;
using VehicleInventory.Domain.CarBrands;

namespace VehicleInventory.Application.CarBrands;

internal sealed class GetCarBrandsQueryHandler : IQueryHandler<GetCarBrandsQuery, List<CarBrandDto>>
{
    private readonly ICarBrandsRepository _carBrandsRepository;

    internal GetCarBrandsQueryHandler(ICarBrandsRepository carBrandsRepository)
    {
        _carBrandsRepository = carBrandsRepository;
    }

    public async Task<List<CarBrandDto>> Handle(GetCarBrandsQuery request, CancellationToken cancellationToken)
    {
        var brands = await _carBrandsRepository.GetAllCarBrands();

        return brands.Select(x => new CarBrandDto()
        {
            CarBrandId = x.Id,
            BrandName = x.Name
        }).ToList();
    }
}
