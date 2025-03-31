using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Municipalidad;
[Table("RelacionImpuesto")]
public partial class RelacionImpuesto
{

    [Key]
    public long id_relacion { get; set; }

    public string periodo { get; set; } = null!;

    public long id_contribuyente { get; set; }

    public long id_tipoimpuesto { get; set; }
    public bool anulado { get; set; }
    public int id_municipio { get; set; }






}
