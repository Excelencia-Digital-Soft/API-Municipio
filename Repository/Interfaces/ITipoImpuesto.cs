using Models.DTOs;

namespace Repository.Interfaces
{
    public interface ITipoImpuestoRepository
    {
        Task<List<ListadoGeneralListadoTipoImpuestoDTO>> getTipoImpuesto(int pTipo, int pId);

        

    }
}
