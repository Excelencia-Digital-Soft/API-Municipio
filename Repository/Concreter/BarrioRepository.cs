
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Municipalidad;
using Repository.Interfaces;

namespace Repository.Concreter
{
    public class BarrioRepository : IBarrioRepository// : BaseRepositoryReceta<Receta>, IRecetaRepository
    {
        private MunicipalidadContext _context;
        public BarrioRepository(MunicipalidadContext context)
        {
            _context = context; 

        }

        public async Task<List<ListadoGeneralBarriosDTO>> ListadoBarrios(int  pId)
        {

            return await _context.Barrios.Where( a => a.id_departamento == pId).
                Select(a => new ListadoGeneralBarriosDTO { id_barrio = a.id_barrio, nombre = a.nombre_barrio.Trim() }).
                ToListAsync()  ;

           
        }
        public async Task<List<ListadoGeneralBarriosDTO>> Grabar_Registros(int pId)
        {
            // Insertar un nuevo barrio (si es necesario)
            var nuevoBarrio = new Barrio
            {
                nombre_barrio = "BARRIOultimo",  // Nombre del barrio
                id_departamento = 2       // ID del departamento
            };

            _context.Barrios.Add(nuevoBarrio);
            await _context.SaveChangesAsync();

            // Retornar la lista de barrios filtrados por id_departamento
            return await _context.Barrios
            .OrderByDescending(a => a.id_barrio) // Ordena por ID de barrio en orden descendente
            .Take(1) // Toma solo el primer registro
            .Select(a => new ListadoGeneralBarriosDTO
            {
                id_barrio = a.id_barrio,
                nombre = a.nombre_barrio.Trim()
            })
            .ToListAsync();
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
