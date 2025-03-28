using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Recetas
{
    [Table("Recetas")]
    public class Receta
    {
        [Key]
        public int IdReceta { get; set; }

        [Required]
        public int IdInstitucion { get; set; } = 0;

        [Required]
        [StringLength(11)]
        [Column(TypeName = "nchar")]
        public string Documento { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        [StringLength(150)]
        [Column(TypeName = "nchar")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        [Column(TypeName = "nchar")]
        public string SexoAfiliado { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "date")]
        public DateTime FecNacAfiliado { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "nchar")]
        public string DomicilioAfiliado { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Column(TypeName = "nchar")]
        public string NroAfiliado { get; set; } = string.Empty;

        [Required]
        public int IdObraSocial { get; set; } = 0;

        [Required]
        [StringLength(150)]
        [Column(TypeName = "nchar")]
        public string NombreObraSocial { get; set; } = string.Empty;

        [Required]
        public int IdPlan { get; set; } = 0;

        [Required]
        [StringLength(150)]
        [Column(TypeName = "nchar")]
        public string NombrePlan { get; set; } = string.Empty;

        [Required]
        [StringLength(4)]
        [Column(TypeName = "nchar")]
        public string MatriculaMedico { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [Column(TypeName = "nchar")]
        public string NombreMedico { get; set; } = string.Empty;

        [Required]
        [StringLength(80)]
        [Column(TypeName = "nchar")]
        public string EspecialidadMedico { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        [Column(TypeName = "nchar")]
        public string DomicilioMedico { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime FecCrea { get; set; } = DateTime.Now;

        [Required]
        public Guid Unico { get; set; } = Guid.NewGuid();

        [Required]
        public bool Entregado { get; set; } = false;

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime EntregadoFecha { get; set; } = DateTime.MinValue;
    }
}
