using Domain.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTOs;

namespace Services.Interfaces
{
    public interface ILoginServices
    {
        //Task<RespuestaDTO> ValidateUser(string username, string password);
        Task<RespuestaDTO> Registrarse(RegistrarDTO user);
        Task<RespuestaDTO> GetUser(LoginDto datos);
    }
}
