using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.HCWebApp
{
    public partial class Prestador
    {
        public int? IdPrestador { get; set; }
        public Guid? Uid { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Cuit { get; set; }
        public int? IdTipoSexo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? IdTipoEstadoCivil { get; set; }
        public int? IdPais { get; set; }
        public int? IdProvincia { get; set; }
        public int? IdDepartamento { get; set; }
        public int? IdLocalidad { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }
        public string TelFijo { get; set; }
        public string TelCelular { get; set; }
        public string Cbu { get; set; }
        public int? IdBanco { get; set; }
        public int? IdSucursal { get; set; }
        public string CuentaBanco { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaEgreso { get; set; }
        public int? IdCondicionIva { get; set; }
        public int? IngresosBrutos { get; set; }
        public DateTime? FechaGraduacion { get; set; }
        public string Categoria { get; set; }
        public bool? Guardias { get; set; }
        public bool? AlquilaConsultorio { get; set; }
        public bool GeneraCheque { get; set; }
        public bool? GeneraCertificadoIB { get; set; }
        public bool? GeneraCertifGanancia { get; set; }
        public bool? Habilitado { get; set; }
        public int IdTipoPrestador { get; set; }
        public DateTime? ObraSocialAltaFecha { get; set; }
        public bool ObraSocialBaja { get; set; }
        public DateTime? ObraSocialBajaFecha { get; set; }
        public int IdObraSocialBajaMotivo { get; set; }
        public string Convenio { get; set; }
        public string Matricula { get; set; }
        public DateTime? MatriculaFecha { get; set; }
        public int IdEspecialidad { get; set; }
        public string TelConsultorio { get; set; }
        public int IdLugarAtencion { get; set; }
        public int? IdUsuario { get; set; }
        public int IdPlantilla { get; set; }
        public bool Anulado { get; set; }
        public string SndEsp { get; set; }
        public DateTime? FechaHoraCrea { get; set; }
        public int IdTipoBaja { get; set; }
        public DateTime FechaBaja { get; set; }
        public bool TurnosWEB { get; set; }
        public int IdSubEspecialidad1 { get; set; }
        public int IdSubEspecialidad2 { get; set; }
        public int IdSubEspecialidad3 { get; set; }
        public int IdUsuarioCrea { get; set; }
        public DateTime FecCrea { get; set; }
        public int IdUsuarioAnula { get; set; }
        public DateTime FecAnula { get; set; }
        public int IdUsuarioModi { get; set; }
        public DateTime FecModi { get; set; }
        public bool Tercerizado { get; set; }
        public bool PedidoConMembrete { get; set; }
        public bool? MostrarEnTurnosApp { get; set; }
        public string ImgPerfil { get; set; }
        public string AccessToken { get; set; }
        public string PublikKey { get; set; }
        public int? ValorConsulta { get; set; }
        public int? PorcentajeConsulta { get; set; }
        public bool? CobroMercadoPago { get; set; }
        public string CobroMP { get; set; }
        public bool? MostrarEstudiosApp { get; set; }
        public bool? SUF { get; set; }
    }
}
