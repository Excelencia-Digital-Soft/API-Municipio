using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Municipalidad;
[Table("TipoImpuesto")]
public partial class TipoImpuesto
{

    [Key]
    public int id_tipo_impuesto { get; set; }

    public string nombre_impuesto { get; set; } = null!;
    public string descripcion { get; set; } = null!;
    public decimal porcentaje_tasa { get; set; }
    public DateTime fecha_vigencia_inicio { get; set; }
    public DateTime fecha_vigencia_fin { get; set; }

    public int estado { get; set; }

    public int id_municipio { get; set; }






}
