using System;
using System.Collections.Generic;

namespace Models.Municipalidad;

public partial class Role
{
    public int RolId { get; set; }

    public string RolName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
