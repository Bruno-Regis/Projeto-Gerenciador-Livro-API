using GerenciadorLivro.Core.Repositories;
using GerenciadorLivro.Infrastructure.Persistence;
using GerenciadorLivro.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace GerenciadorLivro.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register DbContext, Repositories, and other infrastructure services here
            services
                .AddRepositories()
                .AddData(configuration);
            return services;
        }
        
        private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("GerenciadorLivrosCs");
            services.AddDbContext<LivrosDbContext>(o => o.UseSqlServer(connectionString));

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Register repository implementations here
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
            return services;
        }

    }
}
