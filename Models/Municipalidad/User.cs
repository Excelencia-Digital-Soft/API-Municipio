using System;
using System.Collections.Generic;

namespace Models.Municipalidad;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? RoleId { get; set; }

    public DateOnly? FechaEliminacion { get; set; }

    public string? Email { get; set; }

    public int Institucionid { get; set; }

    public virtual Role? Role { get; set; }
}
