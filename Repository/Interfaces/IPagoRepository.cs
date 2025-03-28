using Models.DTOs;
using Models.Municipalidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPagoRepository
    {
        Task<List<ListadoGeneralDTO>> ListadoPagos(int pId_Municipio, DateTime pFechaDesde, DateTime pFechaHasta);
    }
}
