using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Municipalidad;
[Table("Contribuyente")]
public partial class Contribuyente
{

    [Key]
    public int id_contribuyente { get; set; }

    public string tipo_documento { get; set; } = null!;
    public string nombres { get; set; } = null!;
    public string apellidos { get; set; } = null!;
    public string razon_social { get; set; } = null!;
    public string direccion { get; set; } = null!;
    public int id_distrito { get; set; }
    public string email { get; set; } = null!;
    public string telefono { get; set; } = null!;

    public DateTime fecha_registro { get; set; }

    public int estado { get; set; }
    public int id_municipio { get; set; }
    public int id_barrio { get; set; }
    public string cantidad { get; set; } = null!;
    public int anulado { get; set; }






}
