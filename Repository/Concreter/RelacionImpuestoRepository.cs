
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Municipalidad;
using Repository.Interfaces;

namespace Repository.Concreter
{
    public class RelacionImpuestoRepository : IRelacionImpuestoRepository // : BaseRepositoryReceta<Receta>, IRecetaRepository
    {
        private MunicipalidadContext _context;
        public RelacionImpuestoRepository(MunicipalidadContext context)
        {
            _context = context; 

        }

        public async Task GrabarRelacion(string Perido, long id_c, long id_imp, int  pId)
        {

            //return await _context.RelacionImpuestos.Where( a => a.id_departamento == pId).
            //    Select(a => new RelacionDTO { id_barrio = a.id_barrio, nombre = a.nombre_barrio.Trim() }).
            //    ToListAsync()  ;

            // Insertar un nuevo barrio (si es necesario)
            var nuevoRelacion = new  RelacionImpuesto
            {
                periodo = Perido,  // Periodo
                id_contribuyente = id_c,       // ID del Contribuyente
                id_tipoimpuesto = id_imp, //ID de tipo de impuesto
                id_municipio = pId //id de Municipalidad 

            };
            _context.RelacionImpuestos.Add(nuevoRelacion);
            await _context.SaveChangesAsync();

            



        }
        public async Task<List<RelacionDTO>> ListarDatos(int pId, long pC)
        {
            return await _context.RelacionImpuestos
            .OrderByDescending(a => a.periodo) // Ordena por ID de barrio en orden descendente
            .Take(1) // Toma solo el primer registro
            .Select(a => new RelacionDTO
            {
                periodo = a.periodo,
                id_contribuyente = a.id_contribuyente,
                id_municipio=a.id_municipio,    
                id_tipoimpuesto = a.id_tipoimpuesto
            })
            .ToListAsync();

        }//    // Insertar un nuevo barrio (si es necesario)
        //    var nuevoBarrio = new Barrio
        //    {
        //        nombre_barrio = "BARRIOultimo",  // Nombre del barrio
        //        id_departamento = 2       // ID del departamento
        //    };

        //    _context.Barrios.Add(nuevoBarrio);
        //    await _context.SaveChangesAsync();

        //    // Retornar la lista de barrios filtrados por id_departamento
        //    return await _context.Barrios
        //    .OrderByDescending(a => a.id_barrio) // Ordena por ID de barrio en orden descendente
        //    .Take(1) // Toma solo el primer registro
        //    .Select(a => new ListadoGeneralBarriosDTO
        //    {
        //        id_barrio = a.id_barrio,
        //        nombre = a.nombre_barrio.Trim()
        //    })
        //    .ToListAsync();
        //}


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
