using Models.DTOs;

namespace Repository.Interfaces
{
    public interface IRelacionImpuestoRepository
    {
        Task GrabarRelacion(string Perido, long id_c, long id_imp, int pId);
        Task<List<RelacionDTO>> ListarDatos(int pId, long pC);
    }
}
