using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Municipalidad;
[Table("Factura")]
public partial class Factura
{

    [Key]
    [Column("id_factura")]
    public int id_factura { get; set; }
    public int id_inmueble { get; set; }
    public int id_tipo_impuesto { get; set; }

    public string periodo { get; set; } = null!;

    public DateTime fecha_emision { get; set; }
    public DateTime fecha_vencimiento { get; set; }

    public decimal monto_base { get; set; }
    public decimal tasa_aplicable { get; set; }
    public decimal monto_total { get; set; }
    public string estado { get; set; } = null!;
    public DateTime fecha_pago { get; set; }
    public decimal monto_pagado { get; set; }
    public decimal saldo_pendiente { get; set; }

    public int id_municipio { get; set; }







}
