using System.Net;
using Configurator.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Configurator.API.Controllers;

public class CarConfiguratorController
{
    [Route("api/cars/configurations")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [Route("/model")]
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SetCarModelInConfiguration([FromBody]SetConfigurationCarModelRequest request)
        {
            return Ok();
        }   
        
        [Route("/engine")]
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SetCarEngineInConfiguration([FromBody]SetConfigurationCarEngineRequest request)
        {
            return Ok();
        }   
        
        [Route("/color")]
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SetCarColorInConfiguration([FromBody]SetConfigurationColorRequest request)
        {
            return Ok();
        } 
        
        [Route("/rims")]
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SetCarRimsInConfiguration([FromBody]SetConfigurationRimsRequest request)
        {
            return Ok();
        }  
        
        [Route("/interior")]
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SetCarInteriorInConfiguration([FromBody]SetConfigurationInteriorRequest request)
        {
            return Ok();
        } 
        
        [Route("/extras")]
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SetCarExtrasInConfiguration([FromBody]SetConfigurationExtrasRequest request)
        {
            return Ok();
        } 
        
        [Route("/order")]
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Order([FromBody]SetConfigurationExtrasRequest request)
        {
            return Ok();
        } 
    }

}