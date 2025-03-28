using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Services.Interfaces;

namespace Municipalidad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class MController : ControllerBase
    {
        //private IMunucipalidadServices _recetaServices;

       // public RecetaController(IMunicipalidadServices recetaServices)
        //{
         //   _recetaServices = recetaServices;
        //}

        //[Authorize]
        //[HttpPost("agregar-pago")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Respuesta))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        //public async Task<IActionResult> AgregarPago(RecetaRequestDto receta)
        //{
        //    var resp = await _recetaServices.AgregarPago(receta);

        //    if (resp.Success) 
        //        return new OkObjectResult(resp);

        //    return new BadRequestObjectResult(resp);
        //}
    }
}
