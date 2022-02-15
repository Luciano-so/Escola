using Escola.Core.Entities;
using Escola.Domain.Contracts.IRepositorys;
using Escola.Domain.Contracts.IServices;
using Escola.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Domain.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task Adicionar(Curso curso)
        {
            curso.Validar();

            await _cursoRepository.Adicionar(curso);
            await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task Alterar(Curso curso)
        {
            curso.Validar();

            var banco = await _cursoRepository.ObterPorId(curso.Id);
            Validacoes.ValidarSeNulo(banco, "Curso não encontrado");

            _cursoRepository.Alterar(curso);
            await _cursoRepository.UnitOfWork.Commit();
        }

        public IEnumerable<Curso> ListarTodosCursos()
        {
            return _cursoRepository.ListarTodosCursos();
        }

        public IEnumerable<Curso> ListarTodosCursoseAlunos()
        {
            return _cursoRepository.ListarTodosCursoseAlunos();
        }
    }
}
