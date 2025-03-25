
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Municipalidad;
using Repository.Interfaces;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repository.Concreter
{
    public class ContribuyenteRepository : IContribuyenteRepository
    {
        private MunicipalidadContext _context;
        public ContribuyenteRepository(MunicipalidadContext context)
        {
            _context = context; 

        }
        public async Task<List<ListadoGeneralContribuyenteDTO>> ListadoContribuyente(int pId_Municipio, string pDNI, int pTipo)
        {
            
            using (var context = new MunicipalidadContext())
            {
                return await context.Database
                    .SqlQueryRaw<ListadoGeneralContribuyenteDTO>("EXEC ListadoContribuyentes @pId_Municipio, @pDNI, @pTipo",
                                                                 new SqlParameter("@pId_Municipio", pId_Municipio),
                                                                 new SqlParameter("@pDNI", pDNI),
                                                                 new SqlParameter("@pTipo", pTipo))
                    .ToListAsync();
            }

        }


    }
}
