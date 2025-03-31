using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class LoginDto
    {
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
    }

    public class LoginGeneralDto
    {
        public string Token { get; set; } = string.Empty;
        public string Rol { get; set; }
        public string UsuarioID { get; set; }
        public string UsuarioName { get; set; }
        public string Instituciones_id { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
    }

    public class ListadoPagosGenerarDTO
    {
        public int pId_Municipio { get; set; }
        public string Periodo { get; set; }
        public int id_tipo_impuesto { get; set; }
        public int tipo { get; set; }


    }
    public class ListadoPagosDTO
    {
        public int pId { get; set; }
        public DateTime pFechaDesde { get; set; }
        public DateTime pFechaHasta { get; set; }
        


    }
    public class ListadoContribuyenteDTO
    {
        public int pId_Municipio { get; set; }
        public string pDNI { get; set; }

        public int pTipo { get; set; }

    }
    public class ListadoGeneralContribuyenteDTO
    {
        public string tipo_documento { get; set; }
        public string nro_documento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string razon_social { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string id_municipio { get; set; }
        public string nombremunicipio { get; set; }
        public string id_barrio { get; set; }
        public string nombre_barrio { get; set; }

    }
    public class ListadoBarriosDTO
    {
        public int pId { get; set; }
        
    }
    public class ListadoUsuarioDTO
    {
        public int pId { get; set; }

    }
    public class ListadoGeneralListadoUsuarioDTO
    {
        public string UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string RolId { get; set; }
        public string nombre_rol { get; set; }
        public string id_municipio { get; set; }
        public string municipio { get; set; }
        public string contrasenia { get; set; }

   
    }
    public class ListadoDepartamentoDTO
    {
        public int pId { get; set; }

    }
    public class ListadoGeneralDepartamentoDTO
    {
        public int id_departamento { get; set; }
        public string nombre { get; set; }

    }
    public class ListadoGeneralBarriosDTO
    {
        public int id_barrio { get; set; }
        public string nombre { get; set; }

    }
    public class ListadoMunicipalidadDTO
    {
        public int pId { get; set; }

    }
    public class ListadoGeneralMunicipalidadDTO
    {
        public int id_municipio { get; set; }
        public string nombre { get; set; }

    }
    public class ListadoTipoImpuestoDTO
    {
        public int pId { get; set; }

    }
    public class ListadoTipoImpuestoCDTO
    {
        public int pContribuyenteId { get; set; }

    }
    public class RelacionDTO
    {
        public string periodo { get; set; }
        public long id_contribuyente { get; set; }
        public long id_tipoimpuesto { get; set; }
        public int id_municipio { get; set; }

    }
    public class ListarRelacionDTO
    {
        public string periodo { get; set; } = string.Empty;
        public string id_contribuyente { get; set; } = string.Empty;
        public string id_tipoimpuesto { get; set; } = string.Empty;
        public string id_municipio { get; set; } = string.Empty;

    }
    public class ListadoGeneralListadoTipoImpuestoCDTO
    {
        public string id_inmueble { get; set; }
        public string direccion_inmueble { get; set; }
        public string mza { get; set; }
        public string lote { get; set; }
        public string zona { get; set; }
        public string area_total { get; set; }
        public string id_tipoimpuesto { get; set; }
        public string id_contribuyente { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string nombre_impuesto { get; set; }
        
       
    }
    public class ListadoGeneralListadoTipoImpuestoDTO
    {
        public string id_tipo_impuesto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string porcentaje_tasa { get; set; }
        public DateTime fecha_vigencia_inicio { get; set; }
        public DateTime fecha_vigencia_fin { get; set; }

        
          



    }
    
        public class ListadoGeneralGenerarDTO
    {
        public string return_value { get; set; }
    }
    public class RegistrarDTO
    {
        public string usuario { get; set; }
        public int rol { get; set; }
        public int id_municipio { get; set; }
        public string contrasenia { get; set; }
        public string email { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }




    }
    public class ListadoGeneralDTO
    {
        public string Identificador { get; set; }

        public string nro_documento { get; set; }
        public string Nombres { get; set; }

        public string Apellidos { get; set; } = null!;

        public string Calle { get; set; } = null!;

        public string nombre_barrio { get; set; } = null!;
        public string Manzana { get; set; } = null!;

        public string Lote { get; set; } = null!;

        public string Zona { get; set; } = null!;

        public string Mtslineales { get; set; }

        public string Form { get; set; }

        public string Uc { get; set; }

        public string Monto { get; set; }

        public string Numrecibo { get; set; } = null!;

        ////public string Fechapago { get; set; }

        public string Fechavencimiento { get; set; }
        public string pagado { get; set; }
        public string saldo { get; set; }
        public string estado { get; set; }
    }
}
