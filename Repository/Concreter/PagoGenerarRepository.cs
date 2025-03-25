
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Municipalidad;
using Repository.Interfaces;

namespace Repository.Concreter
{
    public class PagoGenerarRepository : IPagoGenerarRepository
    {
        private MunicipalidadContext _context;
        public PagoGenerarRepository(MunicipalidadContext context)
        {
            _context = context; 

        }
        public async Task<List<ListadoGeneralDTO>> ListadoGenerarPagos(int pId_Municipio, string pPeriodo, int id_tipo_impuesto, int Tipo)
        {
            using (var context = new MunicipalidadContext())
            {
                return await context.Database
                    .SqlQueryRaw<ListadoGeneralDTO>("EXEC GenerarFacturas @pId_Municipio, @pPeriodo, @pid_tipo_impuesto, @Tipo",
                        new SqlParameter("@pId_Municipio", pId_Municipio),
                        new SqlParameter("@pPeriodo", pPeriodo),
                        new SqlParameter("@pid_tipo_impuesto", id_tipo_impuesto),
                        new SqlParameter("@Tipo", Tipo))
                    .ToListAsync();
            }

        }





    }
}
