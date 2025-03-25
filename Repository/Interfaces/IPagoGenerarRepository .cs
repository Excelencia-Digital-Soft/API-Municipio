using Models.DTOs;
using Models.Municipalidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPagoGenerarRepository
    {
        Task<List<ListadoGeneralDTO>> ListadoGenerarPagos(int pId_Municipio, string pPeriodo, int id_tipo_impuesto, int Tipo);
    }
}
