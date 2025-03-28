using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.MomentoApp;


namespace Models
{
    static public class ModalsExtension
    {
        public static void ConfigureModel(this IServiceCollection services, IConfigurationManager Configuration)
        {
            services.AddDbContext<RecetasAppContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("Recetas")));
            services.AddDbContext<RecetasAppContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("Municipalidad")));

            services.AddDbContext<HCWebAppContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ZismedAppContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Zismed")));
        }
    }
}
