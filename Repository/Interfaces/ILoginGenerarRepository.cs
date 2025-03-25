using Models.DTOs;
using Models.Municipalidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ILoginGenerarRepository
    {
        Task<List<LoginGeneralDto>> ListadoLogin(string NombreUsuario, string Contrasenia);
    }
}
