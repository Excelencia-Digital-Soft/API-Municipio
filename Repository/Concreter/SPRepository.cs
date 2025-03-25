
using Models;
using Models.MomentoApp;
using Models.Municipalidad;
using Repository.Interfaces;
using System.Runtime.InteropServices;

namespace Repository.Concreter
{

    public class SPRepository //:  IAspNetUserRepository
    {
        private MunicipalidadContext context;


        public SPRepository(MunicipalidadContext context) 
        {

            this.context = context; 
        }

       


        //public async Task<User> GetUserByUsuario (string usuario)
        //{
        //    return table.Where(u => u.Usuario == usuario.Trim() && !u.Anulado).FirstOrDefault() ?? null;
        //}


       

        //public async Task<User> GetUserByCuil(string cuil)
        //{
        //    return table.Where(u => u.Cuil == cuil && !u.Anulado).FirstOrDefault() ?? null;
        //}

    }
}
