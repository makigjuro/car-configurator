using System.Net;
using Configurator.Application.Commands;
using Configurator.Application.Queries;
using Configurator.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Configurator.API.Controllers;

[Route("api/cars/configurations")]
[ApiController]
public class CarConfiguratorController : Controller
{
    private readonly IMediator _mediator;

    public CarConfiguratorController(IMediator mediator)
    {
        this._mediator = mediator;
    }
    
    [Route("")]
    [HttpGet]
    [ProducesResponseType(typeof(List<ConfigurationDto>), (int)HttpStatusCode.OK)]
    public async Task<List<ConfigurationDto>> GetAllConfigurations()
    {
        // return await _mediator.Send(new GetAllConfigurationsQuery());

        return new List<ConfigurationDto>()
        {
            new ConfigurationDto()
            {
                ConfigurationId = new Guid(),
                Name = "My Configuration for Tesla S"
            },
            new ConfigurationDto()
            {
                ConfigurationId = new Guid(),
                Name = "My Configuration for Tesla S second"
            },

            new ConfigurationDto()
            {
                ConfigurationId = new Guid(),
                Name = "My Configuration for Tesla Model X"
            },

            new ConfigurationDto()
            {
                ConfigurationId = new Guid(),
                Name = "My Configuration for Tesla Model Y"
            }
        };
    }   


    [Route("model")]
    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> SetCarModelInConfiguration([FromBody]SetConfigurationCarModelRequest request)
    {
        await _mediator.Send(new SetConfigurationCarModelCommand()
        {
            CarBrandId = request.CarBrandId,
            CarConfigurationId = request.CarConfigurationId,
            CarModelDto = request.CarModel
        });
        return Ok();
    }   
    
    [Route("engine")]
    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> SetCarEngineInConfiguration([FromBody]SetConfigurationCarEngineRequest request)
    {
        await _mediator.Send(new SetConfigurationCarEngineCommand()
        {
            CarBrandId = request.CarBrandId,
            CarConfigurationId = request.CarConfigurationId,
            CarEngine = request.CarEngine
        });

        return Ok();
    }   
    
    [Route("color")]
    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> SetCarColorInConfiguration([FromBody]SetConfigurationColorRequest request)
    {
        await _mediator.Send(new SetConfigurationCarColorCommand()
        {
            CarBrandId = request.CarBrandId,
            CarConfigurationId = request.CarConfigurationId,
            CarColor = request.CarColor
        });

        return Ok();
    } 
    
    [Route("rims")]
    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> SetCarRimsInConfiguration([FromBody]SetConfigurationRimsRequest request)
    {
        await _mediator.Send(new SetConfigurationCarRimsCommand()
        {
            CarBrandId = request.CarBrandId,
            CarConfigurationId = request.CarConfigurationId,
            CarRims = request.CarRims
        });

        return Ok();
    }  
    
    [Route("interior")]
    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> SetCarInteriorInConfiguration([FromBody]SetConfigurationInteriorRequest request)
    {
        await _mediator.Send(new SetConfigurationCarInteriorCommand()
        {
            CarBrandId = request.CarBrandId,
            CarConfigurationId = request.CarConfigurationId,
            CarInterior = request.CarInterior
        });

        return Ok();
    } 
    
    [Route("extras")]
    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> SetCarExtrasInConfiguration([FromBody]SetConfigurationExtrasRequest request)
    {
        await _mediator.Send(new SetCarConfigurationExtraCommand()
        {
            CarBrandId = request.CarBrandId,
            CarConfigurationId = request.CarConfigurationId,
            CarExtra = request.CarExtras
        });

        return Ok();
    } 
    
    [Route("order")]
    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Order([FromBody]SetConfigurationExtrasRequest request)
    {
        return Ok();
    } 
}
    