using Domain;
using Models.DTOs;

namespace Services.Interfaces
{
    public interface IMunucipalidadServices
    {

        Task<Respuesta> getpagos(ListadoPagosDTO datos);
        Task<Respuesta> getbarrios( int id_municipio);
        Task<Respuesta> getmuni(ListadoMunicipalidadDTO datos);
        Task<Respuesta> getTipoImpuesto(ListadoMunicipalidadDTO datos, int id_municipio);
        Task<Respuesta> getDepartamento(ListadoDepartamentoDTO datos);
        Task<Respuesta> getContribuyente(ListadoContribuyenteDTO datos);
        Task<Respuesta> getUsuario(ListadoUsuarioDTO datos);
        Task<Respuesta> getPagoGenerar(ListadoPagosGenerarDTO datos, int id_municipio);
        Task<Respuesta> getLoginGenerar(LoginDto datos);

    }
}