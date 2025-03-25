using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Municipalidad;
[Table("Barrio")]
public partial class Barrio
{

    [Key]
    public int id_barrio { get; set; }

    public string nombre_barrio { get; set; } = null!;

    public int id_departamento { get; set; }

    public int anulado { get; set; }






}
