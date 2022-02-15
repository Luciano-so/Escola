using Escola.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Escola.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AutoMapperRegister(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AlunoNotaMappingProfile), typeof(CursoMappingProfile), typeof(AlunoMappingProfile), typeof(AlunoCursoMappingProfile));
        }
    }
}
