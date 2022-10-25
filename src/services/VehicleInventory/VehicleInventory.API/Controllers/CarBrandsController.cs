using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleInventory.Application.CarBrands;

namespace VehicleInventory.API.Controllers;

[Route("api/brands")]
[ApiController]
public class CarBrandsController : Controller
{
    private readonly IMediator _mediator;

    public CarBrandsController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<CarBrandDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCarBrands()
    {
        var brands = await _mediator.Send(new GetCarBrandsQuery());

        return Ok(brands);
    }      
}
