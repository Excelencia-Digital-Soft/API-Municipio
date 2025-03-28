using Models.Recetas;

namespace Repository.Interfaces
{
    public interface IRecetaRepository : IBaseRepository<Receta>
    {
        Task<Receta> GetRecetaByDNI(string dni);
    }
}