using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class RespuestaSingIn
    {
        public string Token { get; set; }

        public int IdUser { get; set; }

        public string NameFull { get; set; } = null!;

        public string Cuil { get; set; } = null!;

        public string Email { get; set; } = null!;


    }
}
