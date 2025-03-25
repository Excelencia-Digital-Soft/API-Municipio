using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Municipalidad;
[Table("Usuario")]
public partial class Usuario
{

    [Key]
    public int id_usuario { get; set; }

    public string nombre_usuario { get; set; } = null!;
    public string nombre { get; set; } = null!;

    public string contrasenia { get; set; }

    public string apellido { get; set; }=string.Empty;
    public string email { get; set; }
    public int id_rol { get; set; }
    public int id_municipio { get; set; }
    public bool estado { get; set; }
    public DateTime fecha_registro { get; set; } = DateTime.Now;

    








}
