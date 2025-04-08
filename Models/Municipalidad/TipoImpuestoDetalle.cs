
using System.ComponentModel.DataAnnotations;

namespace Models.Municipalidad
{
    public class TipoImpuestoDetalle
    {
        [Key]
        public int  id_tipo_impuesto { get; set; }
        public string  descripcion { get; set; }
        public decimal porcentaje_tasa { get; set; }
        public DateTime fecha_vigencia_inicio { get; set; }
        public DateTime fecha_vigencia_fin { get; set; }
        public bool estado { get; set; }
        public int id_municipio { get; set; }
        public int id_tipoImpuesto { get; set; }


    }
}