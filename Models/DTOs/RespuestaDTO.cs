using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class RespuestaDTO
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class UnicoID
    {
        public int IdReceta { get; set; }
        public Guid Unico { get; set; }
    }
}
