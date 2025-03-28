using Models.DTOs;

namespace Repository.Interfaces
{
    public interface ITipoImpuestoCRepository
    {
        Task<List<ListadoGeneralListadoTipoImpuestoCDTO>> getTipoImpuestoC(int pTipo, int pId);




    }
}
