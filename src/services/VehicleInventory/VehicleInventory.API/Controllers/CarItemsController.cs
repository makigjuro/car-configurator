using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleInventory.Application.CarItems;
using VehicleInventory.Application.CarItemTypes;

namespace VehicleInventory.API.Controllers;

[Route("api/cars/items")]
[ApiController]
public class CarItemsController : Controller
{
    private readonly IMediator _mediator;

    public CarItemsController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<CarItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCarItems(Guid carItemTypeId, Guid carModelId)
    {
        var items = await _mediator.Send(new GetCarItemQuery(carItemTypeId, carModelId));

        return Ok(items);
    }      
    
    [HttpGet]
    [Route("types")]
    [ProducesResponseType(typeof(List<CarItemTypesDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCarItemsTypes()
    {
        var items = await _mediator.Send(new GetCarItemTypeQuery());

        return Ok(items);
    }      

}
