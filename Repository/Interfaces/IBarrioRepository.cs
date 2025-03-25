using Models.DTOs;

namespace Repository.Interfaces
{
    public interface IBarrioRepository
    {
        Task<List<ListadoGeneralBarriosDTO>> ListadoBarrios(int pId);
    }
}
