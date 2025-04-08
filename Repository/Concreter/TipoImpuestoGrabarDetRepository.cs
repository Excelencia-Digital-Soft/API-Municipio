
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Municipalidad;
using Repository.Interfaces;
using System.Reflection.Metadata;

namespace Repository.Concreter
{
    public class TipoImpuestoGrabarDetRepository : ITipoImpuestoGrabarDetRepository // : BaseRepositoryReceta<Receta>, IRecetaRepository
    {
        private MunicipalidadContext _context;
        public TipoImpuestoGrabarDetRepository(MunicipalidadContext context)
        {
            _context = context; 

        }

        public async Task postGrabarTipoImpuestoDet(string pNombre , string pTasa, string pFecha, string pIdtipo, int pId)
        {

            // Insertar un nuevo TipoImpuesto
            var tipoImpuesto = new TipoImpuestoDetalle
            {
                descripcion = "-",
                porcentaje_tasa = Convert.ToDecimal(pTasa),
                fecha_vigencia_inicio = Convert.ToDateTime(pFecha),
                fecha_vigencia_fin = Convert.ToDateTime("01/01/1900"),
                estado = false,
                id_municipio = pId,
                id_tipoImpuesto = Convert.ToInt32(pIdtipo)

            };
            _context.TipoImpuestoDetalles.Add(tipoImpuesto);
            await _context.SaveChangesAsync();






        }
        public async Task<List<ListadoGeneralListadoTipoImpuestoDTO>> ListarDatos(int pId)
        {
            return await _context.TipoImpuestoDetalles
            .OrderByDescending(a => a.id_municipio) // Ordena por ID de barrio en orden descendente
            .Select(a => new ListadoGeneralListadoTipoImpuestoDTO
            {
                id_tipo_impuesto = a.id_tipo_impuesto.ToString(),
                nombre = a.descripcion,
                descripcion = a.descripcion, 
                porcentaje_tasa = a.porcentaje_tasa.ToString(),
                fecha_vigencia_inicio = a.fecha_vigencia_inicio,
                fecha_vigencia_fin = a.fecha_vigencia_fin,
        
            })
            .ToListAsync();

        }
    }
}
