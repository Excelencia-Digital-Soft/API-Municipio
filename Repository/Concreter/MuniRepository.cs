
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Municipalidad;
using Repository.Interfaces;

namespace Repository.Concreter
{
    public class MuniRepository : IMuniRepository// : BaseRepositoryReceta<Receta>, IRecetaRepository
    {
        private MunicipalidadContext _context;
        public MuniRepository(MunicipalidadContext context)
        {
            _context = context; 

        }

        public async Task<List<ListadoGeneralMunicipalidadDTO>> ListadoMuni(int  pId)
        {
           
            return await _context.Municipios.Where( a => a.id_provincia == pId).
                Select(a => new ListadoGeneralMunicipalidadDTO { id_municipio = a.id_municipio, nombre = a.nombre.Trim() }).
                ToListAsync()  ;
        }

       



    }
}
