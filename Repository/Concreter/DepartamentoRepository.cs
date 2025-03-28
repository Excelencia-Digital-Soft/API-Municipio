
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Municipalidad;
using Repository.Interfaces;

namespace Repository.Concreter
{
    public class DepartamentoRepository : IDepartamentoRepository// : BaseRepositoryReceta<Receta>, IRecetaRepository
    {
        private MunicipalidadContext _context;
        public DepartamentoRepository(MunicipalidadContext context)
        {
            _context = context; 

        }

        public async Task<List<ListadoGeneralDepartamentoDTO>> ListadoDepartamento(int  pId)
        {
           
            return await _context.Departamentos.Where( a => a.id_provincia == pId).
                Select(a => new ListadoGeneralDepartamentoDTO { id_departamento = a.id_departamento, nombre = a.nombre_departamento.Trim() }).
                ToListAsync()  ;
        }


        //public async Task<User> GetUserByEmail(string Mail)
        //{
        //    return table.Where(u => u.Mail == Mail.Trim() && !u.Anulado).FirstOrDefault() ?? null;
        //}

        //public async Task<User> GetUserByCuil(string cuil)
        //{
        //    return table.Where(u => u.Cuil == cuil && !u.Anulado).FirstOrDefault() ?? null;
        //}

    }
}
