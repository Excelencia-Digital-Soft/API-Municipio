using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Municipalidad;
[Table("Inmueble")]
public partial class Inmueble
{

    [Key]
    public int id_inmueble { get; set; }
    public int id_contribuyente { get; set; }

    public string direccion_inmueble { get; set; } = null!;

    public int id_distrito { get; set; }
    public string tipo_inmueble { get; set; } = null!;

    public decimal valor_catastral { get; set; }
    public decimal area_construida { get; set; }
    public decimal area_total { get; set; }
    public DateTime fecha_registro { get; set; }
    public int estado { get; set; }
    public int id_municipio { get; set; }
    public string mza { get; set; } = null!;
    public string lote { get; set; } = null!;
    public string zona { get; set; } = null!;
    public string form { get; set; } = null!;
    public int id_barrio { get; set; }

    






}
