using Models.DTOs;
using Models.Municipalidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<ListadoGeneralListadoUsuarioDTO>> ListadoUsuario(int pId_Municipio);
        Task SaveRegistro(Usuario User);
        Task<Usuario?> VerificarUsuario(string nombre_usuario);
        Task<bool> Verificaremail(string email);
    }
}
