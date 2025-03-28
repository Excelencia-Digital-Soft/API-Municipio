
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.DTOs;
using Models.Municipalidad;
using Repository.Interfaces;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repository.Concreter
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private MunicipalidadContext _context;
        public UsuarioRepository(MunicipalidadContext context)
        {
            _context = context; 

        }
        public async Task<List<ListadoGeneralListadoUsuarioDTO>> ListadoUsuario(int pId_Municipio)
        {
            
            using (var context = new MunicipalidadContext())
            {
                return await context.Database
                    .SqlQueryRaw<ListadoGeneralListadoUsuarioDTO>("EXEC ListadoUsuario @pId_Municipio",
                                                                  new SqlParameter("@pId_Municipio", pId_Municipio))
                    .ToListAsync();
            }

        }
        public async Task SaveRegistro(Usuario User)
        {


            _context.Usuarios.Add(User);
            await _context.SaveChangesAsync();

        }
        public async Task<Usuario?> VerificarUsuario(string nombre_usuario)
        {
            return await _context.Usuarios.Where(u => u.nombre_usuario == nombre_usuario && !u.estado).FirstOrDefaultAsync();
        }
        public async Task<bool> Verificaremail(string email)
        {
            return await _context.Usuarios.AsNoTracking().AnyAsync(u => u.email == email && !u.estado);
        }



    }
}
