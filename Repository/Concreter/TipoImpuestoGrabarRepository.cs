
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Municipalidad;
using Repository.Interfaces;
using System.Reflection.Metadata;

namespace Repository.Concreter
{
    public class TipoImpuestoGrabarRepository : ITipoImpuestoGrabarRepository // : BaseRepositoryReceta<Receta>, IRecetaRepository
    {
        private MunicipalidadContext _context;
        public TipoImpuestoGrabarRepository(MunicipalidadContext context)
        {
            _context = context; 

        }

        public async Task postGrabarTipoImpuesto(string pNombre , string pDescricpion, string ptipo, string pFijo, int pId)
        {
            
            // Insertar un nuevo barrio (si es necesario)
            var tipoImpuesto = new TipoImpuesto
            {
                nombre_impuesto = pNombre,
                descripcion  = pDescricpion,       
                id_tipo_impuesto = Convert.ToInt32(ptipo), 
                fijo = Convert.ToInt32(pFijo),
                id_municipio = pId //id de Municipalidad 

            };
            _context.TipoImpuestos.Add(tipoImpuesto);
            await _context.SaveChangesAsync();




        }
        public async Task<List<ListadoGeneralListadoTipoImpuestoDTO>> ListarDatos(int pId)
        {
            return await _context.TipoImpuestos
            .OrderByDescending(a => a.id_municipio) // Ordena por ID de barrio en orden descendente
            .Take(1) // Toma solo el primer registro
            .Select(a => new ListadoGeneralListadoTipoImpuestoDTO
            {
                id_tipo_impuesto = a.id_tipo_impuesto.ToString(),
                nombre = a.nombre_impuesto,
                descripcion = a.descripcion, 
                porcentaje_tasa = a.porcentaje_tasa.ToString(),
                fecha_vigencia_inicio = a.fecha_vigencia_inicio,
                fecha_vigencia_fin = a.fecha_vigencia_fin,
        
            })
            .ToListAsync();

        }
    }
}
