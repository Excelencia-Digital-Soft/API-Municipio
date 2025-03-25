using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models.DTOs;
using Models.HCWebApp;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Data;


namespace API_Momento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
  
        private ILoginServices _loginServices;
        private IUserRepository _userRepository;
        private IAspNetUserRepository _aspnetuserRepository;
        private IConfiguration _configuration;

        public LoginController(ILoginServices loginServices, IUserRepository userRepository, IAspNetUserRepository aspNetUserRepository, IConfiguration configuration)
        {
            
            _loginServices = loginServices;
            _userRepository = userRepository;
            _aspnetuserRepository = aspNetUserRepository;
            _configuration = configuration;
        }

        //[HttpPost("HCWeb-SingIn")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Respuesta))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        //public async Task<IActionResult> SingIn2([FromBody] SingIn singIn)
        //{
        //    var result = await _loginServices.ValidateUser(singIn.User, singIn.Password);
        //    if (result is null) return new BadRequestObjectResult(result);

        //    return new OkObjectResult(result);
        //}

        [HttpGet("HCWeb-verDatos")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> VerDatos(string email)
        {

            var result = await _userRepository.GetUserByEmail(email);
            if (result is null) return new BadRequestObjectResult(result);

            return new OkObjectResult(result);
        }

        [HttpGet("Zismed-verDatos")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> VerDatosZismed(string email)
        {

            var result = await _aspnetuserRepository.GetUserByEmail(email);
            if (result is null) return new BadRequestObjectResult(result);

            return new OkObjectResult(result);
        }

        [HttpPost("Registrar-Usuario")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> RegistrarUsuario(RegistrarDTO datos )
        {

            var result = await _loginServices.Registrarse(datos);
            if (result.Success)
                return new OkObjectResult(result);
            return new BadRequestObjectResult(result);
            
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Respuesta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Respuesta))]
        public async Task<IActionResult> Login (LoginDto datos)
        {

            var result = await _loginServices.GetUser(datos);
            if (result.Success)
                return new OkObjectResult(result);
            return new BadRequestObjectResult(result);

        }
    }
}
