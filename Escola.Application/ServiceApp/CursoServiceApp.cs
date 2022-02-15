using AutoMapper;
using Escola.Domain.Contracts.IServices;
using Escola.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Application.Services
{
    public class CursoServiceApp : ICursoServiceApp
    {
        private readonly IMapper _mapper;
        private readonly ICursoService _cursoService;

        public CursoServiceApp(IMapper mapper, ICursoService cursoService) => (_mapper, _cursoService) = (mapper, cursoService);

        public async Task Adicionar(CursoAddDto cursoDto)
        {
            var curso = _mapper.Map<Curso>(cursoDto);
            await _cursoService.Adicionar(curso);
        }

        public async Task Alterar(CursoDto cursoDto)
        {
            var curso = _mapper.Map<Curso>(cursoDto);
            curso.Id = cursoDto.Id;
            await _cursoService.Alterar(curso);
        }

        public IEnumerable<CursoDto> ListarTodosCursos()
        {
            return _mapper.Map<IEnumerable<CursoDto>>(_cursoService.ListarTodosCursos());
        }

        public IEnumerable<CursoeAlunoDto> ListarTodosCursoseAlunos()
        {
            var lista = _cursoService.ListarTodosCursoseAlunos();
            var curso = _mapper.Map<IEnumerable<CursoeAlunoDto>>(lista);
            return curso;
        }
    }
}
