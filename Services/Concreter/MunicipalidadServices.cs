﻿using Domain;
using Microsoft.Extensions.Logging;
using Models.DTOs;
using Repository.Concreter;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Concreter
{
    public class MunicipalidadServices: IMunucipalidadServices
    {
        private IPagoRepository _pagoRepository;
        private IPagoGenerarRepository  _pagoGenerarRepository;
        private IExceptionsServices _exceptionsservices;
        private IUnitOfWork _unitOfWork;
        private IBarrioRepository _barrioRepository;
        private IMuniRepository _muniRepository;
        private ITipoImpuestoRepository _tipoImpuestoRepository;
        private IDepartamentoRepository _DepartamentoRepository;
        private IContribuyenteRepository _ContribuyenteRepository;
        private IUsuarioRepository _UsuarioRepository;
        private ILoginGenerarRepository _loginRepository;
        private ITipoImpuestoCRepository _tipoImpuestoCRepository;
        private IRelacionImpuestoRepository _relacionImpuestoRepository;
        private ITipoImpuestoGrabarRepository _tipoImpuestoGrabarRepository;
        private ITipoImpuestoGrabarDetRepository _tipoImpuestoGrabarDetRepository;




        private ILogger<MunicipalidadServices> _logger;

        public IMuniRepository MuniRepository { get => _muniRepository; set => _muniRepository = value; }

        public MunicipalidadServices(IPagoRepository pago,
                                     IExceptionsServices exceptionsservices,
                                     IUnitOfWork unitOfWork,
                                     IBarrioRepository barrioRepository,
                                     IMuniRepository muniRepository,
                                     IDepartamentoRepository departamentoRepository,
                                     ITipoImpuestoRepository tipoImpuestoRepository,
                                     IContribuyenteRepository contribuyenteRepository,
                                     IUsuarioRepository usuarioRepository,
                                     IPagoGenerarRepository pagoGenerarRepository,
                                     ITipoImpuestoCRepository tipoImpuestoCRepository,
                                     ILoginGenerarRepository loginRepository,
                                     IRelacionImpuestoRepository relacionImpuestoRepository,
                                     ITipoImpuestoGrabarRepository tipoImpuestoGrabarRepository,
                                     ITipoImpuestoGrabarDetRepository tipoImpuestoGrabarDetRepository,
                                     ILogger<MunicipalidadServices> logger)
        {
            _pagoRepository = pago;
            _exceptionsservices = exceptionsservices;
            _unitOfWork = unitOfWork;
            _barrioRepository = barrioRepository;
            _muniRepository = muniRepository;
            _tipoImpuestoRepository = tipoImpuestoRepository;
            _DepartamentoRepository = departamentoRepository;   
            _ContribuyenteRepository = contribuyenteRepository;
            _UsuarioRepository = usuarioRepository;
            _pagoGenerarRepository = pagoGenerarRepository;
            _loginRepository = loginRepository;
            _tipoImpuestoCRepository = tipoImpuestoCRepository;
            _relacionImpuestoRepository = relacionImpuestoRepository;
            _tipoImpuestoGrabarRepository = tipoImpuestoGrabarRepository;
            _tipoImpuestoGrabarDetRepository = tipoImpuestoGrabarDetRepository;

            _logger = logger;
        }

        public async Task<Respuesta>getpagos(ListadoPagosDTO datos)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "User";

            try
            {
                var pagos = await _pagoRepository.ListadoPagos(datos.pId, datos.pFechaDesde, datos.pFechaHasta);
                if(pagos is null)
                {
                    respuesta.Message = "Listado Sin datos";  
                    return respuesta;
                }
                respuesta.Data = pagos;
                respuesta.Success = true;   
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR");
                respuesta.Success = false;
                respuesta.Data = 0;
                respuesta.Message = ex.Message;
            }

            return respuesta;
        }
        public async Task<Respuesta> getbarrios( int id_municipio)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "User";

            try
            {
                var barrio = await _barrioRepository.ListadoBarrios(id_municipio);
                if (barrio is null)
                {
                    respuesta.Message = "Listado Sin datos";
                    return respuesta;
                }
                respuesta.Data = barrio;
                respuesta.Success = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR");
                respuesta.Success = false;
                respuesta.Data = 0;
                respuesta.Message = ex.Message;
            }

            return respuesta;
        }
        public async Task<Respuesta> getmuni(ListadoMunicipalidadDTO datos)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "User";

            try
            {
                var muni = await _muniRepository.ListadoMuni(datos.pId);
                if (muni is null)
                {
                    respuesta.Message = "Listado Sin datos";
                    return respuesta;
                }
                respuesta.Data = muni;
                respuesta.Success = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR");
                respuesta.Success = false;
                respuesta.Data = 0;
                respuesta.Message = ex.Message;
            }

            return respuesta;
        }
        public async Task<Respuesta> getTipoImpuesto(ListadoMunicipalidadDTO datos, int id_municipio)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "User";

            try
            {
                var muni = await _tipoImpuestoRepository.getTipoImpuesto(datos.pId,id_municipio);
                if (muni is null)
                {
                    respuesta.Message = "Listado Sin datos";
                    return respuesta;
                }
                respuesta.Data = muni;
                respuesta.Success = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR");
                respuesta.Success = false;
                respuesta.Data = 0;
                respuesta.Message = ex.Message;
            }

            return respuesta;
        }
        public async Task<Respuesta> postGrabarTipoImpuesto(GrabarTipoImpuestoDTO datos, int id_municipio)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "User";

            try
            {
                

                await _tipoImpuestoGrabarRepository.postGrabarTipoImpuesto(datos.nombre_impuesto, datos.descripcion, datos.tipo, datos.fijo, id_municipio);
                var muni = await _tipoImpuestoGrabarRepository.ListarDatos(id_municipio);
                if (muni is null)
                {
                    respuesta.Message = "Listado Sin datos";
                    return respuesta;
                }
                respuesta.Data = muni;
                respuesta.Success = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR");
                respuesta.Success = false;
                respuesta.Data = 0;
                respuesta.Message = ex.Message;
            }

            return respuesta;
        }
        public async Task<Respuesta> postGrabarTipoImpuestoDet(GrabarTipoImpuestoDetDTO datos, int id_municipio)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "User";

            try
            {


                await _tipoImpuestoGrabarDetRepository.postGrabarTipoImpuestoDet(datos.detalle, datos.tasa, datos.fecha_vigencia_inicio, datos.id_tipoImpuesto, id_municipio);
                var muni = await _tipoImpuestoGrabarRepository.ListarDatos(id_municipio);
                if (muni is null)
                {
                    respuesta.Message = "Listado Sin datos";
                    return respuesta;
                }
                respuesta.Data = muni;
                respuesta.Success = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR");
                respuesta.Success = false;
                respuesta.Data = 0;
                respuesta.Message = ex.Message;
            }

            return respuesta;
        }
        public async Task<Respuesta> getTipoImpuestoC(ListadoTipoImpuestoCDTO datos, int id_municipio)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "User";

            try
            {
                var muni =  await _tipoImpuestoCRepository.getTipoImpuestoC(datos.pContribuyenteId, id_municipio);
                if (muni is null)
                {
                    respuesta.Message = "Listado Sin datos";
                    return respuesta;
                }
                respuesta.Data = muni;
                respuesta.Success = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR");
                respuesta.Success = false;
                respuesta.Data = 0;
                respuesta.Message = ex.Message;
            }

            return respuesta;
        }
        public async Task<Respuesta> getRelacion(RelacionDTO datos, int id_municipio)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "User";

            try
            {
                await _relacionImpuestoRepository.GrabarRelacion(datos.periodo, datos.id_contribuyente, datos.id_tipoimpuesto, id_municipio);
                var muni = await _relacionImpuestoRepository.ListarDatos(id_municipio, datos.id_contribuyente);
                if (muni is null)
                {
                    respuesta.Message = "Listado Sin datos";
                    return respuesta;
                }
                respuesta.Data = muni;
                respuesta.Success = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR");
                respuesta.Success = false;
                respuesta.Data = 0;
                respuesta.Message = ex.Message;
            }

            return respuesta;
        }
        public async Task<Respuesta> getDepartamento(ListadoDepartamentoDTO datos)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "User";

            try
            {
                var muni = await _DepartamentoRepository.ListadoDepartamento(datos.pId);
                if (muni is null)
                {
                    respuesta.Message = "Listado Sin datos";
                    return respuesta;
                }
                respuesta.Data = muni;
                respuesta.Success = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR");
                respuesta.Success = false;
                respuesta.Data = 0;
                respuesta.Message = ex.Message;
            }

            return respuesta;
        }
        public async Task<Respuesta> getContribuyente(ListadoContribuyenteDTO datos)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "User";

            try
            {
                var contribuyente = await _ContribuyenteRepository.ListadoContribuyente(datos.pId_Municipio, datos.pDNI, datos.pTipo);
                if (contribuyente is null)
                {
                    respuesta.Message = "Listado Sin datos";
                    return respuesta;
                }
                respuesta.Data = contribuyente;
                respuesta.Success = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR");
                respuesta.Success = false;
                respuesta.Data = 0;
                respuesta.Message = ex.Message;
            }

            return respuesta;

            


        }

        public async Task<Respuesta> getUsuario(ListadoUsuarioDTO datos)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "User";

            try
            {
                var usuario = await _UsuarioRepository.ListadoUsuario(datos.pId); 
                if (usuario is null)
                {
                    respuesta.Message = "Listado Sin datos";
                    return respuesta;
                }
                respuesta.Data = usuario;
                respuesta.Success = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR");
                respuesta.Success = false;
                respuesta.Data = 0;
                respuesta.Message = ex.Message;
            }

            return respuesta;
        }

        public async Task<Respuesta> getPagoGenerar(ListadoPagosGenerarDTO datos, int id_municipio)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "User";

            try
            {
                var generar = await _pagoGenerarRepository.ListadoGenerarPagos(id_municipio, datos.Periodo, datos.id_tipo_impuesto, datos.tipo);
                if (generar is null)
                {
                    respuesta.Message = "Listado Sin datos";
                    return respuesta;
                }
                respuesta.Data = generar;
                respuesta.Success = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR");
                respuesta.Success = false;
                respuesta.Data = 0;
                respuesta.Message = ex.Message;
            }

            return respuesta;
        }
        public async Task<Respuesta> getLoginGenerar(LoginDto datos)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "User";

            try
            {
                var generar = await _loginRepository.ListadoLogin(datos.NombreUsuario, datos.Contrasenia);
                if (generar is null)
                {
                    respuesta.Message = "Listado Sin datos";
                    return respuesta;
                }
                respuesta.Data = generar;
                respuesta.Success = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR");
                respuesta.Success = false;
                respuesta.Data = 0;
                respuesta.Message = ex.Message;
            }

            return respuesta;
        }
    }
}

