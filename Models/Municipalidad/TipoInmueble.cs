using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Municipalidad;
[Table("TipoInmueble")]
public partial class TipoInmueble
{

    [Key]
    public int tipoid { get; set; }

    public string nombre { get; set; } = null!;

   


}
