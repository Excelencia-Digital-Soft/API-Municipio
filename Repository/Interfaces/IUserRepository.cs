using Models.MomentoApp;


namespace Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByUsuario(string usuario);
        Task<User> GetUserByEmail(string Mail);
        Task<User> GetUserByCuil(string cuil);
    }
}
