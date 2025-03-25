using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Municipalidad;
[Table("Departamento")]
public partial class Departamento
{

    [Key]
    public int id_departamento { get; set; }

    public string nombre_departamento { get; set; } = null!;
    public int id_provincia { get; set; }


}
