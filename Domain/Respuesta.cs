using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Respuesta
    {
        public bool Success { get; set; } = false;
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
