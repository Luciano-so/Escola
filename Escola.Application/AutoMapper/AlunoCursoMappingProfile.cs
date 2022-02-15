using AutoMapper;
using Escola.Domain.Entities;

namespace Escola.Application.AutoMapper
{
    public class AlunoCursoMappingProfile : Profile
    {
        public AlunoCursoMappingProfile()
        {
            CreateMap<AlunoCursoDto, AlunoCurso>()
                .ConstructUsing(c => AlunoCurso.Factory.Create(c.AlunoId, c.CursoId))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<AlunoCursoEditDto, AlunoCurso>()
                .ConstructUsing(c => AlunoCurso.Factory.Create(c.AlunoId, c.CursoId))
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<AlunoCurso, AlunoCursoViewDto>()
                .ForMember(dest => dest.Aluno, opt => opt.MapFrom(x => x.Aluno.Nome))
                .ForMember(dest => dest.Curso, opt => opt.MapFrom(x => x.Curso.Nome))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<AlunoCurso, AlunoCursoNotaDto>()
               .ForMember(dest => dest.Notas, opt => opt.MapFrom(x => x.AlunoNota))
               .ForMember(dest => dest.Curso, opt => opt.MapFrom(x => x.Curso.Nome))
               .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
