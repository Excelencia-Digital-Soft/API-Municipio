using Domain.DTOs;
using Domain;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Concreter
{
    public class UsersServices: IUsersServices
    {
        private IUserRepository _userrepository;
        private IExceptionsServices _exceptionsservices;

        public UsersServices(IUserRepository userRepository, IExceptionsServices exceptionsservices)
        {
            _userrepository = userRepository;
            _exceptionsservices = exceptionsservices;
        }

        public async Task<Respuesta> GetUserByIdUser(int IdUser)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Message = "User";
            try
            {
                var user = _userrepository.GetById(IdUser);
                if (user is null)
                    throw new Exception($"No se encontro el usuario");

                var dataUser = new UserData
                {
                    NameFull = user.Nombre,
                    Username = user.Cuil
                };

                respuesta.Success = true;
                respuesta.Data = dataUser;
            }
            catch (Exception ex)
            {
                respuesta.Success = true;
                respuesta.Data = ex.Message;

            }

            return respuesta;
        }
    }
}
