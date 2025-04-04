using Models.DTOs;

namespace Repository.Interfaces
{
    public interface ITipoImpuestoGrabarRepository
    {
        Task postGrabarTipoImpuesto(string pNombre, string pDescricpion, string ptipo, string pFijo, int pId);
        Task<List<ListadoGeneralListadoTipoImpuestoDTO>> ListarDatos(int pId);




    }
}
