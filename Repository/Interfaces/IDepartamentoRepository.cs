using Models.DTOs;

namespace Repository.Interfaces
{
    public interface IDepartamentoRepository
    {
        Task<List<ListadoGeneralDepartamentoDTO>> ListadoDepartamento(int pId);
    }
}
