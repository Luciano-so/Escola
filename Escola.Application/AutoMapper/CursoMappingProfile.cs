using AutoMapper;
using Escola.Domain.Entities;

namespace Escola.Application.AutoMapper
{
    public class CursoMappingProfile : Profile
    {
        public CursoMappingProfile()
        {
            CreateMap<CursoDto, Curso>()
                .ConstructUsing(c => Curso.Factory.Create(c.Nome))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<CursoAddDto, Curso>()
               .ConstructUsing(c => Curso.Factory.Create(c.Nome))
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .IgnoreAllPropertiesWithAnInaccessibleSetter()
               .ReverseMap();

            CreateMap<CursoeAlunoDto, Curso>()
              .ConstructUsing(c => Curso.Factory.Create(c.Nome))
              .ForMember(dest => dest.AlunoCurso, opt => opt.MapFrom(x => x.Alunos))
              .ForMember(dest => dest.Id, opt => opt.Ignore())
              .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<Curso, CursoeAlunoDto>()
             .ForMember(dest => dest.Alunos, opt => opt.MapFrom(x => x.AlunoCurso))
             .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
