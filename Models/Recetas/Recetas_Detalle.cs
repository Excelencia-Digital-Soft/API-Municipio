using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Recetas
{
    [Table("Recetas_Detalle")]
    public class RecetaDetalle
    {
        [Key]
        public int IdDetalle_Receta { get; set; }

        [Required]
        public int IdReceta { get; set; }

        [Required]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NroRegistro { get; set; } = 0;

        [Required]
        [StringLength(200)]
        [Column(TypeName = "nchar")]
        public string NombreMedicamento { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "int")]
        public int Cantidad { get; set; } = 0;

        [Required]
        [Column(TypeName = "int")]
        public int IdDiagnostico { get; set; } = 0;

        [Required]
        [StringLength(10)]
        [Column(TypeName = "nchar")]
        public string CodigoDiagnostico { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        [Column(TypeName = "nchar")]
        public string Diagnostico { get; set; } = string.Empty;

    }
}
