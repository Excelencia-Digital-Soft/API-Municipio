
using Models;
using Models.MomentoApp;
using Repository.Interfaces;

namespace Repository.Concreter
{
    public class AspNetUsersRepository : ZismedBaseRepository<AspNetUser>, IAspNetUserRepository
    {

        public AspNetUsersRepository(ZismedAppContext _zismedcontext) : base(_zismedcontext)
        {

        }

        
        //public async Task<User> GetUserByUsuario (string usuario)
        //{
        //    return table.Where(u => u.Usuario == usuario.Trim() && !u.Anulado).FirstOrDefault() ?? null;
        //}


        public async Task<AspNetUser> GetUserByEmail(string Mail)
        {
            return table.Where(u => u.Email == Mail.Trim()).FirstOrDefault() ?? null;
        }

        //public async Task<User> GetUserByCuil(string cuil)
        //{
        //    return table.Where(u => u.Cuil == cuil && !u.Anulado).FirstOrDefault() ?? null;
        //}

    }
}
