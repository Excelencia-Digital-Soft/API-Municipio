using System;
using System.Collections.Generic;

namespace Models.Municipalidad;

public partial class Pago
{
    public long id_pago { get; set; }
    public long id_factura { get; set; }
    public long id_contribuyente { get; set; }
    public DateTime fecha_pago { get; set; }
    public decimal monto_pagado { get; set; }
    public string metodo_pago { get; set; } = null!;
    public string nro_comprobante { get; set; } = null!;
    public string observaciones { get; set; } = null!;
    public long id_municipio { get; set; }
    
}
