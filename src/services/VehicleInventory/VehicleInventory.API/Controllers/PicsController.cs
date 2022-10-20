using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleInventory.Infrastructure.Domain;

namespace VehicleInventory.API.Controllers;

[ApiController]
public class PicController : ControllerBase
{
    private readonly IWebHostEnvironment _env;
    private readonly VehicleInventoryContext _vehicleInventoryContext;

    public PicController(IWebHostEnvironment env,
        VehicleInventoryContext vehicleInventoryContext)
    {
        _env = env;
        _vehicleInventoryContext = vehicleInventoryContext;
    }

    [HttpGet]
    [Route("api/catalog/items/{carItemId}/pic")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    // GET: /<controller>/
    public async Task<ActionResult> GetItemImageAsync(Guid carItemId)
    {
        if (carItemId == Guid.Empty)
        {
            return BadRequest();
        }

        var item = await _vehicleInventoryContext.CarItems
            .SingleOrDefaultAsync(ci => ci.Id == carItemId);

        if (item != null)
        {
            var webRoot = _env.WebRootPath;
            var path = Path.Combine(webRoot, item.PictureFileName);

            string imageFileExtension = Path.GetExtension(item.PictureFileName);
            string mimetype = GetImageMimeTypeFromImageFileExtension(imageFileExtension);

            var buffer = await System.IO.File.ReadAllBytesAsync(path);

            return File(buffer, mimetype);
        }

        return NotFound();
    }
    
    [HttpGet]
    [Route("api/catalog/models/{carModelId}/pic")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    // GET: /<controller>/
    public async Task<ActionResult> GetModelImageAsync(Guid carModelId)
    {
        if (carModelId == Guid.Empty)
        {
            return BadRequest();
        }

        var item = await _vehicleInventoryContext.CarModels
            .SingleOrDefaultAsync(ci => ci.Id == carModelId);

        if (item != null)
        {
            var webRoot = _env.WebRootPath;
            var path = Path.Combine(webRoot, item.PictureFileName);

            string imageFileExtension = Path.GetExtension(item.PictureFileName);
            string mimetype = GetImageMimeTypeFromImageFileExtension(imageFileExtension);

            var buffer = await System.IO.File.ReadAllBytesAsync(path);

            return File(buffer, mimetype);
        }

        return NotFound();
    }


    private string GetImageMimeTypeFromImageFileExtension(string extension)
    {
        string mimetype = extension switch
        {
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".jpg" or ".jpeg" => "image/jpeg",
            ".bmp" => "image/bmp",
            ".tiff" => "image/tiff",
            ".wmf" => "image/wmf",
            ".jp2" => "image/jp2",
            ".svg" => "image/svg+xml",
            _ => "application/octet-stream",
        };
        return mimetype;
    }
}