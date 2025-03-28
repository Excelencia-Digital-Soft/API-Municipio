using Domain;
using Domain.DTOs;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.DTOs;
using Models.HCWebApp;
using Models.MomentoApp;
using Models.Municipalidad;
using Repository.Interfaces;
using Services.Interfaces;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Concreter
{
    public class LoginServices : ILoginServices
    {
        private IConfiguration _configuration;
        private IPasswordHasher _passwordHasher;
        private IUsuarioRepository _usuarioRepository;  

        

        public LoginServices(IConfiguration configuration, IUsuarioRepository usuarioRepository)
        {
            _passwordHasher = new PasswordHasher();
            _configuration = configuration;
           _usuarioRepository = usuarioRepository;
        }


        //public async Task<RespuestaDTO> ValidateUser(string username, string password)
        //{
        //    var resp = new RespuestaDTO();
        //    resp.Message = "Credenciales Invalidas";

        //    try
        //    {
        //        using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        //        {
        //            await connection.OpenAsync();

        //            using (var command = new SqlCommand("[dbo].[USUARIO_VALIDAR_ACCESO_CON_EMAIL]", connection))
        //            {
        //                command.CommandType = CommandType.StoredProcedure;
        //                command.Parameters.AddWithValue("@usuario", (object)username ?? DBNull.Value);
        //                command.Parameters.AddWithValue("@email", (object)username ?? DBNull.Value);
        //                command.Parameters.AddWithValue("@pass", password);

        //                var resultParameter = new SqlParameter("@result", SqlDbType.Bit)
        //                {
        //                    Direction = ParameterDirection.Output
        //                };
        //                command.Parameters.Add(resultParameter);

        //                using (var reader = await command.ExecuteReaderAsync())
        //                {
        //                    // Inicializa las instituciones como una lista vacía
        //                    var institucionIds = new List<int>();

        //                    if (await reader.ReadAsync())
        //                    {
        //                        resp.Success = true;
        //                        resp.Message = "Login Exitoso!";

        //                        // Crear el objeto UsuarioDTO
        //                        var usuario = new LoginUserDTO
        //                        {
        //                            IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario")),
        //                            IdPrestador = reader.GetInt32(reader.GetOrdinal("IdPrestador")),
        //                            Usuario = reader["Usuario"].ToString(),
        //                            Mail = reader["Mail"].ToString(),
        //                            Nombre = reader["Nombre"].ToString(),
        //                            Apellido = reader["Apellido"].ToString(),
        //                            DNI = reader["NumeroDocumento"].ToString(),
        //                            Cuit = reader["Cuit"].ToString(),
        //                            IdTipoSexo = reader.GetInt32(reader.GetOrdinal("IdTipoSexo")),
        //                            Instituciones = institucionIds, // Inicialmente vacía
        //                            FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento")),
        //                            Domicilio = reader["Domicilio"].ToString(),
        //                            TelFijo = reader["TelFijo"].ToString(),
        //                            TelCelular = reader["TelCelular"].ToString(),
        //                            FechaGraduacion = reader.GetDateTime(reader.GetOrdinal("FechaGraduacion")),
        //                            Categoria = reader["Categoria"].ToString(),
        //                            Guardias = reader.GetBoolean(reader.GetOrdinal("Guardias")),
        //                            IdTipoPrestador = reader.GetInt32(reader.GetOrdinal("IdTipoPrestador")),
        //                            Matricula = reader["Matricula"].ToString(),
        //                            IdEspecialidad = reader.GetInt32(reader.GetOrdinal("IdEspecialidad")),
        //                            IdPlantilla = reader.GetInt32(reader.GetOrdinal("IdPlantilla")),
        //                            Anulado = reader.GetBoolean(reader.GetOrdinal("Anulado")),
        //                            ImgPerfil = reader["imgPerfil"].ToString(),
        //                            AccessToken = reader["AccessToken"].ToString(),
        //                            PublikKey = reader["PublikKey"].ToString()
        //                        };

        //                        usuario.Token = GetToken(usuario);

        //                        resp.Data = usuario; // Asignar el objeto UsuarioDTO completo a Data
        //                    }

        //                    // Leer los IdInstitucion
        //                    if (await reader.NextResultAsync())
        //                    {
        //                        while (await reader.ReadAsync())
        //                        {
        //                            institucionIds.Add(reader.GetInt32(reader.GetOrdinal("IdInstitucion")));
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resp.Message = ex.Message;
        //        resp.Success = false;
        //    }

        //    return resp;
        //}
        public async Task<RespuestaDTO> Registrarse(RegistrarDTO user)
        {

            var result = new RespuestaDTO();
            try
            {
                var userexit = await _usuarioRepository.VerificarUsuario(user.usuario);
                if (userexit != null)
                {
                    result.Message = "Usuario Existente";
                    return result;

                }
                var userexit_mail = await _usuarioRepository.Verificaremail(user.email);
                if (userexit_mail)
                {
                    result.Message = "EMAIL Existente";
                    return result;

                }
                var usuario = new Usuario();

                usuario.nombre_usuario = user.usuario;
                usuario.contrasenia = _passwordHasher.HashPassword(user.contrasenia);
                usuario.email = user.email.ToLower();
                usuario.id_rol = user.rol;
                usuario.id_municipio = user.id_municipio;
                usuario.apellido = user.apellido;
                usuario.email = user.email;
                usuario.nombre = user.nombre;
                await _usuarioRepository.SaveRegistro(usuario);
                result.Success = true;
                result.Message = "Registro Exitoso"; 
                return result;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                return result;
                
            }
            

            

        }
        public async Task<RespuestaDTO> GetUser(LoginDto datos)
        {




            var result = new RespuestaDTO();
            var usuario = await _usuarioRepository.VerificarUsuario(datos.NombreUsuario);
            if (usuario is null ) 
            {
                result.Message = "Usuario o Contraseña incorrecta";
                return result;  
                
            }
             
            var res = _passwordHasher.VerifyHashedPassword(usuario.contrasenia, datos.Contrasenia);
            if (res == Microsoft.AspNet.Identity.PasswordVerificationResult.Failed)
            {
                result.Message = "Usuario o Contraseña incorrecta";
                return result;
            }

            var datos_user = new LoginGeneralDto
            {
                estado = usuario.estado ? "NO" : "SI",
                Instituciones_id = usuario.id_municipio.ToString(),
                nombre = usuario.nombre,
                Rol = usuario.id_rol.ToString(),
                UsuarioID = usuario.id_usuario.ToString(),
                UsuarioName = usuario.nombre_usuario,
                Token = GetToken(usuario)
            };

            result.Data = datos_user;
            result.Success = true;
            result.Message = "Extito";
            return result;
        }
        public string GetToken(Usuario user)
        {
            var jwtSettingsSub = _configuration.GetSection("Jwt:Subject").Value;
            var jwtSettingsKey = _configuration.GetSection("Jwt:Key").Value;

            var tokenHandler = new JwtSecurityTokenHandler();
            var bytekey = Encoding.UTF8.GetBytes(jwtSettingsKey);

            var tokenDes = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim(JwtRegisteredClaimNames.Name, user.nombre_usuario),
                            new Claim(JwtRegisteredClaimNames.Email, user.email),
                            new Claim("IdUsuario", user.id_usuario.ToString()),
                            new Claim("Id_municipio", user.id_municipio.ToString()),
                            new Claim("id_rol", user.id_rol.ToString())
                        }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bytekey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDes);

            return tokenHandler.WriteToken(token);
        }

        
    }
}
