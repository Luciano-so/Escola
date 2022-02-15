using AutoMapper;
using Escola.Domain.Entities;

namespace Escola.Application.AutoMapper
{
    public class AlunoMappingProfile : Profile
    {
        public AlunoMappingProfile()
        {
            CreateMap<AlunoDto, Aluno>()
                .ConstructUsing(c => Aluno.Factory.Create(c.Nome, c.Cpf))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(x => x.Cpf))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<AlunoViewDto, Aluno>()
                .ConstructUsing(c => Aluno.Factory.Create(c.Nome, c.Cpf))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(x => x.Cpf))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<Aluno, AlunoViewDto>()
                .ForMember(dest => dest.Cursos, opt => opt.MapFrom(x => x.AlunoCurso))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<AlunoListDto, Aluno>()
               .ConstructUsing(c => Aluno.Factory.Create(c.Nome, c.Cpf))
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .IgnoreAllPropertiesWithAnInaccessibleSetter()
               .ReverseMap();
        }
    }
}
