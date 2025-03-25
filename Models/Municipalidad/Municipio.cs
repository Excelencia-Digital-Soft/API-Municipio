using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Municipalidad;
[Table("Municipio")]
public partial class Municipio
{

    [Key]
    public int id_municipio { get; set; }

    public string nombre { get; set; } = null!;

    public int id_provincia { get; set; }
    public DateTime fecha_registro { get; set; }
    

    public int estado { get; set; }






}
