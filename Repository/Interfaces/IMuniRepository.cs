using Models.DTOs;

namespace Repository.Interfaces
{
    public interface IMuniRepository
    {
        Task<List<ListadoGeneralMunicipalidadDTO>> ListadoMuni(int pId);
    }
}
