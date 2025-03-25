using Models;
using Models.MomentoApp;


namespace Repository.Interfaces
{
    public interface IAspNetUserRepository : IBaseRepository<AspNetUser>
    {
        //Task<User> GetUserByUsuario(string usuario);
        Task<AspNetUser> GetUserByEmail(string Mail);
        //Task<User> GetUserByCuil(string cuil);
    }
}
