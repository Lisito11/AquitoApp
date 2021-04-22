using AquitoApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AquitoApi.Controllers
{
    [ApiController]
    [Route("api/image")]
    public class ImageController : ControllerBase
    {
        private readonly ICloudinaryService _cloudinaryService;

        public ImageController(ICloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> PostAsync([FromForm] IFormFile file)
        {

            if (ModelState.IsValid)
            {
                //var fileStream = file.OpenReadStream();


                if (file.Length > 0)
                {

                    string image = await _cloudinaryService.FileUpload(file.FileName, file.OpenReadStream());


                    return Ok(new
                    {
                        Message = "Imagen subida correctamente",
                        ImageURL = image
                    });
                }
            }

            return BadRequest("Faltan o los parametros del formdata han sido mal especificado");
        }
    }
}
