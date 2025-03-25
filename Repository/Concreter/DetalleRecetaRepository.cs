
using Microsoft.EntityFrameworkCore;
using Models.MomentoApp;
using Models.Recetas;
using Repository.Interfaces;

namespace Repository.Concreter
{
    public class DetalleRecetaRepository : BaseRepositoryReceta<RecetaDetalle>, IDetalleRecetaRepository
    {

        public DetalleRecetaRepository(RecetasAppContext _context) : base(_context)
        {

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
