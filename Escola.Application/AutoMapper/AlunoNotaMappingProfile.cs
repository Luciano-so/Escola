using AutoMapper;
using Escola.Domain.Entities;

namespace Escola.Application.AutoMapper
{
    public class AlunoNotaMappingProfile : Profile
    {
        public AlunoNotaMappingProfile()
        {
            CreateMap<AlunoNotaAddDto, AlunoNota>()
               .ConstructUsing(c => AlunoNota.Factory.Create(c.AlunoCursoId, c.Bimestre, c.Nota))
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .IgnoreAllPropertiesWithAnInaccessibleSetter()
               .ReverseMap();

            CreateMap<AlunoNotaEditDto, AlunoNota>()
                .ConstructUsing(c => AlunoNota.Factory.Create(c.AlunoCursoId, c.Bimestre, c.Nota))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<AlunoNota, AlunoNotaAllDto>()
                .ForMember(dest => dest.Aluno, opt => opt.MapFrom(x => x.AlunoCurso.Aluno.Nome))
                .ForMember(dest => dest.Curso, opt => opt.MapFrom(x => x.AlunoCurso.Curso.Nome))
                .ForMember(dest => dest.Bimestre, opt => opt.MapFrom(x => x.Bimeste))
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<AlunoNota, AlunoNotaListDto>()
               .ForMember(dest => dest.Nota, opt => opt.MapFrom(x => x.Nota))
               .ForMember(dest => dest.Bimestre, opt => opt.MapFrom(x => x.Bimeste))
               .IgnoreAllPropertiesWithAnInaccessibleSetter()
               .ReverseMap();
        }
    }
}
