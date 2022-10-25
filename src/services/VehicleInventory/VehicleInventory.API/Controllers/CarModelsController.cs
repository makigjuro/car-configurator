using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleInventory.Application.CarModels;

namespace VehicleInventory.API.Controllers;

[Route("api/cars")]
[ApiController]
public class CarModelsController : Controller
{
    private readonly IMediator _mediator;

    public CarModelsController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<CarModelDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCarModels(Guid brandId)
    {
        var cars = await _mediator.Send(new GetCarModelsQuery(brandId));

        return Ok(cars);
    }      
}
