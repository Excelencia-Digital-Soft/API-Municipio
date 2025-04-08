using Microsoft.Extensions.DependencyInjection;
using Repository.Concreter;
using Repository.Interfaces;


namespace Repository
{
    static public class RepositoryExtension
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAspNetUserRepository, AspNetUsersRepository>();
            services.AddScoped<IExceptionsRepository, ExceptionsRepository>();
            services.AddScoped<IPagoRepository, PagoRepository>();
            services.AddScoped<IBarrioRepository, BarrioRepository>();
            services.AddScoped<IMuniRepository, MuniRepository>();
            services.AddScoped<ITipoImpuestoRepository, TipoImpuestoRepository>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IDetalleRecetaRepository, DetalleRecetaRepository>();
            services.AddScoped<IContribuyenteRepository, ContribuyenteRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPagoGenerarRepository, PagoGenerarRepository>();
            services.AddScoped<ILoginGenerarRepository, LoginRepository>();
            services.AddScoped<ITipoImpuestoCRepository, TipoImpuestoCRepository>();
            services.AddScoped<IRelacionImpuestoRepository, RelacionImpuestoRepository>();
            services.AddScoped<ITipoImpuestoGrabarRepository, TipoImpuestoGrabarRepository>();
            services.AddScoped<ITipoImpuestoGrabarDetRepository, TipoImpuestoGrabarDetRepository>();



        }
    }
}
