using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Municipalidad;
using Repository.Interfaces;


namespace Repository.Concreter
{
    public class LoginRepository : ILoginGenerarRepository// : BaseRepositoryReceta<Receta>, IRecetaRepository
    {
        private MunicipalidadContext _context;
      
        public LoginRepository(MunicipalidadContext context)
        {
            _context = context; 

        }
        
       

        public async Task<List<LoginGeneralDto>> ListadoLogin(string NombreUsuario, string Contrasenia)
        {
            
            using (var context = new MunicipalidadContext())
            {

                //return await context.Database
                //    .SqlQueryRaw<LoginGeneralDto>("EXEC Login @NombreUsuario, @Contrasenia",
                //        new SqlParameter("@NombreUsuario", NombreUsuario),
                //        new SqlParameter("@Contrasenia", Contrasenia))
                //    .ToListAsync();

                var usuarios = await context.Database
                .SqlQueryRaw<LoginGeneralDto>(
                "EXEC Login @NombreUsuario, @Contrasenia",
                new SqlParameter("@NombreUsuario", NombreUsuario),
                new SqlParameter("@Contrasenia", Contrasenia)
                ).ToListAsync();
                var token = "ACA EL VALOR DEL TOKEN";
                // Si no hay resultados, agregar un objeto con Token = "NO"
                if (usuarios == null || !usuarios.Any())
                {
                    usuarios = new List<LoginGeneralDto>
                    {
                        new LoginGeneralDto { estado = "NO" }
                    };
                 }
                else
                {
                    
                    usuarios.ForEach(u =>
                    {
                        u.estado = string.IsNullOrEmpty(u.estado) ? "SI" : "NO";
                        u.Token = token;
                    });

                }


                return usuarios;


            }

        }
      
       
       

       
       
        
       
        //
        // Resumen:
        //     Initializes the Blowfish key schedule.
       
        public async Task<List<ListadoGeneralDTO>> ListadoPagosOk(int pId_Municipio, DateTime pFechaDesde, DateTime pFechaHasta)
        {

            //      return await _context.Facturas
            //.Join(_context.Inmuebles,
            //      f => f.id_inmueble,    // Clave foránea en Facturas
            //      i => i.id_inmueble,    // Clave primaria en Inmuebles
            //      (f, i) => new { f, i }) // Seleccionamos las entidades f (Factura) e i (Inmueble)
            //.Join(_context.TipoImpuestos,
            //      fi => fi.f.id_tipo_impuesto, // Clave foránea en Factura
            //      ti => ti.id_tipo_impuesto,   // Clave primaria en TipoImpuesto
            //      (fi, ti) => new { fi.f, fi.i, ti }) // Unimos también la entidad de TipoImpuesto
            //.Join(_context.Contribuyentes,
            //      fii => fii.i.id_contribuyente, // Clave foránea en Inmuebles
            //      c => c.id_contribuyente,       // Clave primaria en Contribuyentes
            //      (fii, c) => new { fii.f, fii.i, fii.ti, c }) // Unimos también la entidad Contribuyente
            //.Join(_context.Barrios,
            //      fiic => fiic.i.id_barrio,   // Clave foránea en Inmuebles
            //      b => b.id_barrio,           // Clave primaria en Barrios
            //      (fiic, b) => new ListadoGeneralDTO
            //      {
            //          Identificador = fiic.f.id_factura,
            //          Fechavencimiento = fiic.f.fecha_vencimiento,
            //          Calle = fiic.i.direccion_inmueble,
            //          Manzana = fiic.i.mza.Trim(),
            //          Lote = fiic.i.lote.Trim(),
            //          Zona = fiic.i.zona.Trim(),
            //          Form = fiic.i.form.Trim(),
            //          Uc = fiic.ti.nombre_impuesto, // Información del tipo de impuesto
            //          Nombres = fiic.c.nombres, // Concatenar el nombre y apellido del contribuyente
            //          Apellidos = fiic.c.apellidos,
            //          Barrio = b.nombre_barrio, // Información del barrio
            //          Mtslineales = fiic.i.area_total,
            //          Numrecibo = fiic.f.id_factura.ToString(),
            //          Monto = fiic.i.area_total * fiic.ti.porcentaje_tasa

            //      })
            //.ToListAsync();


            return await _context.Facturas
    .Join(_context.Inmuebles,
          f => f.id_inmueble,
          i => i.id_inmueble,
          (f, i) => new { f, i })
    .Join(_context.TipoImpuestos,
          fi => fi.f.id_tipo_impuesto,
          ti => ti.id_tipo_impuesto,
          (fi, ti) => new { fi.f, fi.i, ti })
    .Join(_context.Contribuyentes,
          fii => fii.i.id_contribuyente,
          c => c.id_contribuyente,
          (fii, c) => new { fii.f, fii.i, fii.ti, c })
    .Join(_context.Barrios,
          fiic => fiic.i.id_barrio,
          b => b.id_barrio,
          (fiic, b) => new { fiic.f, fiic.i, fiic.ti, fiic.c, b })
    .GroupJoin(_context.Pagos,
          fiicb => fiicb.f.id_factura, // Relación con pagos
          p => p.id_factura,
          (fiicb, pagos) => new { fiicb, pagos })
    .Select(data => new ListadoGeneralDTO
    {
        Identificador = data.fiicb.f.id_factura.ToString(),
        //Fechavencimiento = data.fiicb.f.fecha_vencimiento,
        //Calle = data.fiicb.i.direccion_inmueble,
        ///Manzana = data.fiicb.i.mza.Trim(),
        //Lote = data.fiicb.i.lote.Trim(),
        //Zona = data.fiicb.i.zona.Trim(),
        //Form = data.fiicb.i.form.Trim(),
        //Uc = data.fiicb.ti.nombre_impuesto,
        //Nombres = data.fiicb.c.nombres,
        //Apellidos = data.fiicb.c.apellidos,
        //nombre_barrio = data.fiicb.b.nombre_barrio,
        //Mtslineales = data.fiicb.i.area_total.ToString(),
        //Numrecibo = data.fiicb.f.id_factura.ToString()
        //Monto = data.fiicb.i.area_total * data.fiicb.ti.porcentaje_tasa
        //        - data.pagos.Sum(p => (decimal?)p.monto_pagado ?? 0)
    })
    .ToListAsync();






        }
        public async Task<List<ListadoGeneralDTO>> ListadoPagos2(int pId_Municipio, DateTime pFechaDesde, DateTime pFechaHasta)
        {
            var resultado2 = await (from f in _context.Facturas
                                   join i in _context.Inmuebles on f.id_inmueble equals i.id_inmueble
                                   join imp in _context.TipoImpuestos on f.id_tipo_impuesto equals imp.id_tipo_impuesto
                                   join c in _context.Contribuyentes on i.id_contribuyente equals c.id_contribuyente
                                   join b in _context.Barrios on i.id_barrio equals b.id_barrio
                                   //join p in _context.Pagos on f.@id_factura equals p.id_factura into pagosJoin
                                   //from p in pagosJoin.DefaultIfEmpty() // Left Join
                                   where 
                                         i.id_municipio == pId_Municipio &&
                                         f.fecha_emision >= pFechaDesde &&
                                         f.fecha_emision <= pFechaHasta
                                   group new { f, i, imp, c, b } by new
                                   {
                                       f.@id_factura,
                                       c.@nombres,
                                       c.@apellidos,
                                       c.razon_social,
                                       b.nombre_barrio,
                                       f.periodo,
                                       f.fecha_emision,
                                       f.fecha_vencimiento,
                                       i.direccion_inmueble,
                                       imp.nombre_impuesto,
                                       i.mza,
                                       i.lote,
                                       i.zona,
                                       i.form,
                                       i.area_total,
                                       imp.porcentaje_tasa
                                   } into g
                                   select new ListadoGeneralDTO
                                   {


                                       Identificador = g.Key.id_factura.ToString(),

                                       Nombres = g.Key.nombres,
                                      // Apellidos = g.Key.apellidos,
                                       //RazonSocial = g.Key.razon_social,
                                       //Barrio = g.Key.nombre_barrio,
                                       //Periodo = g.Key.periodo,
                                       //FechaEmision = g.Key.fecha_emision,
                                       //Fechavencimiento = g.Key.fecha_vencimiento
                                       //DireccionInmueble = g.Key.direccion_inmueble,
                                       // NombreImpuesto = g.Key.nombre_impuesto,
                                       // Mza = g.Key.mza,
                                       // Lote = g.Key.lote,
                                       // Zona = g.Key.zona,
                                       //Form = g.Key.form,
                                       // UC = g.Key.area_total,
                                       //PorcentajeTasa = g.Key.porcentaje_tasa,
                                       //Total = g.Key.area_total * g.Key.porcentaje_tasa,
                                       //Pagado = g.Sum(x => x.p != null ? x.p.monto_pagado : 0),
                                       //Saldo = (g.Key.area_total * g.Key.porcentaje_tasa) - g.Sum(x => x.p != null ? x.p.monto_pagado : 0),
                                       //Estado = (DateTime.Now > g.Key.fecha_vencimiento) ? "VENCIDA" :
                                       //         ((g.Key.area_total * g.Key.porcentaje_tasa) - g.Sum(x => x.p != null ? x.p.monto_pagado : 0)) == 0 ? "CANCELADO" : "DEUDA"

                                   }).ToListAsync();

            var resultado = await (from f in _context.Facturas
                                   //join i in _context.Inmuebles on f.id_inmueble equals i.id_inmueble
                                   //join imp in _context.TipoImpuestos on f.id_tipo_impuesto equals imp.id_tipo_impuesto
                                   //join c in _context.Contribuyentes on i.id_contribuyente equals c.id_contribuyente
                                  // join b in _context.Barrios on i.id_barrio equals b.id_barrio
                                   //where
                                     //  i.id_municipio == pId_Municipio &&
                                    //   f.fecha_emision >= pFechaDesde &&
                                    //   f.fecha_emision <= pFechaHasta
                                   select new ListadoGeneralDTO
                                   {
                                       Identificador = f.id_factura.ToString(),
                                       //Nombres = c.nombres,
                                       //Apellidos = c.apellidos
                                   }).ToListAsync();

            return resultado;
        }




    }
}
