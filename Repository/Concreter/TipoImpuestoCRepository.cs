
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Municipalidad;
using Repository.Interfaces;

namespace Repository.Concreter
{
    public class TipoImpuestoCRepository : ITipoImpuestoCRepository// : BaseRepositoryReceta<Receta>, IRecetaRepository
    {
        private MunicipalidadContext _context;
        public TipoImpuestoCRepository(MunicipalidadContext context)
        {
            _context = context; 

        }

        public async Task<List<ListadoGeneralListadoTipoImpuestoCDTO>> getTipoImpuestoC(int pTipo, int  pId)
        {
            //return await _context.TipoImpuestos.Where(a => a.id_municipio == pId).
            //Select(a => new ListadoGeneralListadoTipoImpuestoDTO
            //{
            //    id_tipo_impuesto = a.id_tipo_impuesto,
            //    nombre = a.nombre_impuesto.Trim(),
            //    descripcion = a.descripcion,
            //    porcentaje_tasa = a.porcentaje_tasa,
            //    fecha_vigencia_inicio = a.fecha_vigencia_inicio,
            //    fecha_vigencia_fin = a.fecha_vigencia_fin
            //}).
            //ToListAsync();
            using (var context = new MunicipalidadContext())
            {

                    return await context.Database
                    .SqlQueryRaw<ListadoGeneralListadoTipoImpuestoCDTO>("EXEC ListadoTiposContribuyente @pId_Municipio, @pContribuyente",
                        new SqlParameter("@pId_Municipio", pId),
                        new SqlParameter("@pContribuyente", pTipo))
                    .ToListAsync();
            }
                



        }
    }
}
