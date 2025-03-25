using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class MedicamentoDto
    {

        public int NroRegistro { get; set; } = 0;

        public string NombreMedicamento { get; set; } = string.Empty;

        public int Cantidad { get; set; } = 0;

        public int IdDiagnostico { get; set; } = 0;

        public string CodigoDiagnostico { get; set; } = string.Empty;

        public string Diagnostico { get; set; } = string.Empty;
    }

    public class RecetaRequestDto
    {
        public int IdInstitucion { get; set; } = 0;

        public string Documento { get; set; } = string.Empty;

        public DateTime Fecha { get; set; } = DateTime.Now;

        public string Nombre { get; set; } = string.Empty;

        public string SexoAfiliado { get; set; } = string.Empty;

        public DateTime FecNacAfiliado { get; set; }

        public string DomicilioAfiliado { get; set; } = string.Empty;

        public string NroAfiliado { get; set; } = string.Empty;

        public int IdObraSocial { get; set; } = 0;

        public string NombreObraSocial { get; set; } = string.Empty;

        public int IdPlan { get; set; } = 0;

        public string NombrePlan { get; set; } = string.Empty;

        public string MatriculaMedico { get; set; } = string.Empty;

        public string NombreMedico { get; set; } = string.Empty;

        public string EspecialidadMedico { get; set; } = string.Empty;

        public string DomicilioMedico { get; set; } = string.Empty;

        public DateTime FecCrea { get; set; } = DateTime.Now;

        public bool Entregado { get; set; } = false;

        public DateTime EntregadoFecha { get; set; } = DateTime.MinValue;
        public List<MedicamentoDto> Medicamentos { get; set; }
    }
}
