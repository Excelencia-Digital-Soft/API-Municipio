using Domain.DTOs;
using Domain;
using Repository.Interfaces;
using Services.Interfaces;
using Models.Recetas;
using Models.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services.Concreter
{
    public class RecetaServices//: IMunicipalidadServices
    {
        //private IRecetaRepository _recetarepository;
        private IDetalleRecetaRepository _detallerecetarepository;
        private IExceptionsServices _exceptionsservices;
        private IUnitOfWork _unitOfWork;

        public RecetaServices( IDetalleRecetaRepository detalleRecetaRepository , IExceptionsServices exceptionsservices, IUnitOfWork unitOfWork)
        {
           // _recetarepository = recetaRepository;
            _detallerecetarepository = detalleRecetaRepository;
            _exceptionsservices = exceptionsservices;
            _unitOfWork = unitOfWork;
        }

        public async Task<Respuesta> AgregarReceta(RecetaRequestDto receta)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "User";

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var recet = new Receta
                {
                    IdInstitucion = receta.IdInstitucion,
                    Documento = receta.Documento,
                    Fecha = receta.Fecha,
                    Nombre = receta.Nombre,
                    SexoAfiliado = receta.SexoAfiliado,
                    FecNacAfiliado = receta.FecNacAfiliado,
                    DomicilioAfiliado = receta.DomicilioAfiliado,
                    NroAfiliado = receta.NroAfiliado,
                    IdObraSocial = receta.IdObraSocial,
                    NombreObraSocial = receta.NombreObraSocial,
                    IdPlan = receta.IdPlan,
                    NombrePlan = receta.NombrePlan,
                    MatriculaMedico = receta.MatriculaMedico,
                    NombreMedico = receta.NombreMedico,
                    EspecialidadMedico = receta.EspecialidadMedico,
                    DomicilioMedico = receta.DomicilioMedico,
                    FecCrea = receta.FecCrea,
                    Entregado = receta.Entregado,
                    EntregadoFecha = receta.EntregadoFecha

                };

               // _recetarepository.Insert(recet);
               // _recetarepository.Save();

                foreach (var medicamento in receta.Medicamentos)
                {
                    var detalle = new RecetaDetalle
                    {
                        IdReceta = recet.IdReceta,
                        NroRegistro = medicamento.NroRegistro,
                        NombreMedicamento = medicamento.NombreMedicamento,
                        Cantidad = medicamento.Cantidad,
                        IdDiagnostico = medicamento.IdDiagnostico,
                        CodigoDiagnostico = medicamento.CodigoDiagnostico,
                        Diagnostico = medicamento.Diagnostico

                    };

                    _detallerecetarepository.Insert(detalle);

                }

                _detallerecetarepository.Save();
                await _unitOfWork.CommitAsync();

                respuesta.Success = true;
                respuesta.Data = new UnicoID
                {
                    IdReceta = recet.IdReceta,
                    Unico = recet.Unico
                };
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                respuesta.Success = false;
                respuesta.Data = 0;
                respuesta.Message = ex.Message;
            }

            return respuesta;
        }
    }
}
