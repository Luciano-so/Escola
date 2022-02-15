using Escola.Application.Services;
using Escola.Data.Repositories;
using Escola.Domain.Contracts.IRepositorys;
using Escola.Domain.Contracts.IServices;
using Escola.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Escola.Api.Dependencies
{
    public static class DependencyConfig
    {
        public static void DependencyRegister(this IServiceCollection services)
        {
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IAlunoServiceApp, AlunoServiceApp>();

            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<ICursoServiceApp, CursoServiceApp>();

            services.AddScoped<IAlunoNotaRepository, AlunoNotaRepository>();
            services.AddScoped<IAlunoNotaService, AlunoNotaService>();
            services.AddScoped<IAlunoNotaServiceApp, AlunoNotaServiceApp>();

            services.AddScoped<IAlunoCursoRepository, AlunoCursoRepository>();
            services.AddScoped<IAlunoCursoService, AlunoCursoService>();
            services.AddScoped<IAlunoCursoServiceApp, AlunoCursoServiceApp>();
        }
    }
}
