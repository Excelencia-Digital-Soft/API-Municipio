
using Models.MomentoApp;
using Repository.Interfaces;

namespace Repository.Concreter
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(HCWebAppContext _context) : base(_context)
        {

        }

        public async Task<User> GetUserByUsuario (string usuario)
        {
            return table.Where(u => u.Usuario == usuario.Trim() && !u.Anulado).FirstOrDefault() ?? null;
        }

        public async Task<User> GetUserByEmail(string Mail)
        {
            return table.Where(u => u.Mail == Mail.Trim() && !u.Anulado).FirstOrDefault() ?? null;
        }

        public async Task<User> GetUserByCuil(string cuil)
        {
            return table.Where(u => u.Cuil == cuil && !u.Anulado).FirstOrDefault() ?? null;
        }

    }
}
