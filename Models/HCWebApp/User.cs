using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models.MomentoApp;

public partial class User
{
    [Key]
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Direccion { get; set; } // nullable

    public string? Mail { get; set; } = string.Empty; // nullable -> pero te lo guardo como un string vacio 😊

    public string? Telefono_Movil { get; set; } // nullable

    public string? Contrasena { get; set; } // nullable

    public string? Usuario { get; set; } // nullable

    public bool Anulado { get; set; }

    public bool HCU { get; set; }

    public DateTime? FechaHoraCrea { get; set; }

    public DateTime? FechaHoraActualizaPass { get; set; }

    public DateTime? UltimaActividad { get; set; }

    public bool CambioContrasenaRequerido { get; set; }

    public string? Cuil { get; set; } // nullable
}
