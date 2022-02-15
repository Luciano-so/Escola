using AutoMapper;
using Escola.Domain.Contracts.IServices;
using Escola.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Escola.Application.Services
{
    public class AlunoCursoServiceApp : IAlunoCursoServiceApp
    {
        private readonly IMapper _mapper;
        private readonly IAlunoCursoService _alunoCursoService;

        public AlunoCursoServiceApp(IMapper mapper, IAlunoCursoService alunoCursoService) => (_mapper, _alunoCursoService) = (mapper, alunoCursoService);
        public async Task Adiciona(AlunoCursoDto alunoCursoDto)
        {
            var alunoCurso = _mapper.Map<AlunoCurso>(alunoCursoDto);
            await _alunoCursoService.Adiciona(alunoCurso);
        }

        public async Task Alterar(AlunoCursoEditDto alunoCursoDto)
        {
            var alunoCurso = _mapper.Map<AlunoCurso>(alunoCursoDto);
            alunoCurso.Id = alunoCursoDto.Id;
            await _alunoCursoService.Alterar(alunoCurso);
        }

        public async Task Remover(Guid alunoCurso)
        {
            await _alunoCursoService.Remover(alunoCurso);
        }
    }
}
