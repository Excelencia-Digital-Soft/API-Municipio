using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class LoginUserDTO
    {
        public string Token { get; set; }
        public int IdUsuario { get; set; }
        public int IdPrestador { get; set; }
        public string Usuario { get; set; }
        public string Mail { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Cuit { get; set; }
        public int IdTipoSexo { get; set; }
        public List<int> Instituciones { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Domicilio { get; set; }
        public string TelFijo { get; set; }
        public string TelCelular { get; set; }
        public DateTime FechaGraduacion { get; set; }
        public string Categoria { get; set; }
        public bool Guardias { get; set; }
        public int IdTipoPrestador { get; set; }
        public string Matricula { get; set; }
        public int IdEspecialidad { get; set; }
        public int IdPlantilla { get; set; }
        public bool Anulado { get; set; }
        public string ImgPerfil { get; set; }
        public string AccessToken { get; set; }
        public string PublikKey { get; set; }
    }
}
