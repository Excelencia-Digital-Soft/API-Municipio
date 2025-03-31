using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Municipalidad;
using Services.Interfaces;
using System.Security.Claims;

namespace API_Momento.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    
    public class MunicipalidadController : ControllerBase
    {
        private IMunucipalidadServices _MunicipalidadServices;

        public MunicipalidadController(IMunucipalidadServices MunicipalidadServices)
        {
            _MunicipalidadServices = MunicipalidadServices;
        }

        //[Authorize]
        [HttpPost("Listar-Facturas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> GetPagos([FromBody] ListadoPagosDTO DTO)
        {

            var id_rol = "";
            var Id_municipio = 0;
            var IdUsuario = "";
            //#region OBTENER ROL
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                id_rol = claims.Where(x => x.Type.Contains("id_rol")).Select(x => x.Value).FirstOrDefault();
                Id_municipio = int.Parse(claims.Where(x => x.Type.Contains("Id_municipio")).Select(x => x.Value).FirstOrDefault());
                IdUsuario = claims.Where(x => x.Type.Contains("IdUsuario")).Select(x => x.Value).FirstOrDefault();
            }
            var resp = await _MunicipalidadServices.getpagos(DTO);  

            if (resp.Success) 
                return new OkObjectResult(resp);

            return new BadRequestObjectResult(resp);
        }


        [HttpPost("Listar-barrio")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> GetBarrios([FromBody] ListadoBarriosDTO DTO)
        {
            var id_rol = "";
            var Id_municipio = 0;
            var IdUsuario = "";
            //#region OBTENER ROL
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                id_rol = claims.Where(x => x.Type.Contains("id_rol")).Select(x => x.Value).FirstOrDefault();
                Id_municipio = int.Parse(claims.Where(x => x.Type.Contains("Id_municipio")).Select(x => x.Value).FirstOrDefault());
                IdUsuario = claims.Where(x => x.Type.Contains("IdUsuario")).Select(x => x.Value).FirstOrDefault();
            }
            var resp = await _MunicipalidadServices.getbarrios(Id_municipio);

            if (resp.Success)
                return new OkObjectResult(resp);

            return new BadRequestObjectResult(resp);
        }
        [HttpPost("Listar-municipios")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> GetMuni([FromBody] ListadoMunicipalidadDTO DTO)
        {
            var resp = await _MunicipalidadServices.getmuni(DTO);

            if (resp.Success)
                return new OkObjectResult(resp);

            return new BadRequestObjectResult(resp);
        }

        [HttpPost("Listar-TipoImpuestos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> GetTipoImpuesto([FromBody] ListadoMunicipalidadDTO DTO)
        {
            var id_rol = "";
            var Id_municipio = 0;
            var IdUsuario = "";
            //#region OBTENER ROL
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                id_rol = claims.Where(x => x.Type.Contains("id_rol")).Select(x => x.Value).FirstOrDefault();
                Id_municipio = int.Parse(claims.Where(x => x.Type.Contains("Id_municipio")).Select(x => x.Value).FirstOrDefault());
                IdUsuario = claims.Where(x => x.Type.Contains("IdUsuario")).Select(x => x.Value).FirstOrDefault();
            }

            var resp = await _MunicipalidadServices.getTipoImpuesto(DTO,Id_municipio);

            if (resp.Success)
                return new OkObjectResult(resp);

            return new BadRequestObjectResult(resp);
        }
        /// <summary>
        ///  Metodo que retorna listado de Tipos de Impuestos por cada contribuyente
        ///  int pContribuyenteId
        /// </summary>
        [HttpPost("Listar-TipoImpuestosContribuyente")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> GetTipoImpuestoC([FromBody] ListadoTipoImpuestoCDTO DTO)
        {
            var id_rol = "";
            var Id_municipio = 0;
            var IdUsuario = "";
            //#region OBTENER ROL
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                id_rol = claims.Where(x => x.Type.Contains("id_rol")).Select(x => x.Value).FirstOrDefault();
                Id_municipio = int.Parse(claims.Where(x => x.Type.Contains("Id_municipio")).Select(x => x.Value).FirstOrDefault());
                IdUsuario = claims.Where(x => x.Type.Contains("IdUsuario")).Select(x => x.Value).FirstOrDefault();
            }

            var resp = await _MunicipalidadServices.getTipoImpuestoC(DTO, Id_municipio);

            if (resp.Success)
                return new OkObjectResult(resp);

            return new BadRequestObjectResult(resp);
        }
        [HttpPost("Listar-Departamento")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> GetDepartamento([FromBody] ListadoDepartamentoDTO DTO)
        {
            var resp = await _MunicipalidadServices.getDepartamento(DTO);

            if (resp.Success)
                return new OkObjectResult(resp);

            return new BadRequestObjectResult(resp);
        }
        [HttpPost("Listar-Contribuyente")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> GetContribuyente([FromBody] ListadoContribuyenteDTO DTO)
        {
            var resp = await _MunicipalidadServices.getContribuyente(DTO);

            if (resp.Success)
                return new OkObjectResult(resp);

            return new BadRequestObjectResult(resp);
        }
        /// <summary>
        ///  Metodo que graba la relacion de Contribuyente con los impuestos
        ///  int pContribuyenteId
        /// </summary>
        [HttpPost("Grabar-Relacion")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> GetRelacion([FromBody] RelacionDTO DTO)
        {
            var id_rol = "";
            var Id_municipio = 0;
            var IdUsuario = "";
            //#region OBTENER ROL
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                id_rol = claims.Where(x => x.Type.Contains("id_rol")).Select(x => x.Value).FirstOrDefault();
                Id_municipio = int.Parse(claims.Where(x => x.Type.Contains("Id_municipio")).Select(x => x.Value).FirstOrDefault());
                IdUsuario = claims.Where(x => x.Type.Contains("IdUsuario")).Select(x => x.Value).FirstOrDefault();
            }
            var resp = await _MunicipalidadServices.getRelacion(DTO, Id_municipio);

            if (resp.Success)
                return new OkObjectResult(resp);

            return new BadRequestObjectResult(resp);
        }

        [HttpPost("Listar-Usuario")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> GetUsuario([FromBody] ListadoUsuarioDTO DTO)
        {
            var resp = await _MunicipalidadServices.getUsuario(DTO);

            if (resp.Success)
                return new OkObjectResult(resp);

            return new BadRequestObjectResult(resp);
        }


        [HttpPost("Generar-Pagos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> getPagoGenerar([FromBody] ListadoPagosGenerarDTO DTO)
        {
            var id_rol = "";
            var Id_municipio = 0;
            var IdUsuario = "";
            //#region OBTENER ROL
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                id_rol = claims.Where(x => x.Type.Contains("id_rol")).Select(x => x.Value).FirstOrDefault();
                Id_municipio = int.Parse(claims.Where(x => x.Type.Contains("Id_municipio")).Select(x => x.Value).FirstOrDefault());
                IdUsuario = claims.Where(x => x.Type.Contains("IdUsuario")).Select(x => x.Value).FirstOrDefault();
            }

            var resp = await _MunicipalidadServices.getPagoGenerar(DTO, Id_municipio);

            if (resp.Success)
                return new OkObjectResult(resp);

            return new BadRequestObjectResult(resp);
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> getLoginGenerar([FromBody] LoginDto DTO)
        {
            var resp = await _MunicipalidadServices.getLoginGenerar(DTO);

            if (resp.Success)
                return new OkObjectResult(resp);

            return new BadRequestObjectResult(resp);
        }

    }
}
