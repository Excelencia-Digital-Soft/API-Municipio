using Models.DTOs;
using Models.Municipalidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IContribuyenteRepository
    {
        Task<List<ListadoGeneralContribuyenteDTO>> ListadoContribuyente(int pId_Municipio, string pDNI, int pTipo);
    }
}
