using Escola.Core.Entities;
using Escola.Domain.Contracts.IRepositorys;
using Escola.Domain.Contracts.IServices;
using Escola.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Escola.Domain.Services
{
    public class AlunoCursoService : IAlunoCursoService
    {
        private readonly IAlunoCursoRepository _alunoCursoRepository;

        public AlunoCursoService(IAlunoCursoRepository alunoCursoRepository)
        {
            _alunoCursoRepository = alunoCursoRepository;
        }

        public async Task Adiciona(AlunoCurso alunoCurso)
        {
            alunoCurso.Validar();

            await _alunoCursoRepository.Adicionar(alunoCurso);
            await _alunoCursoRepository.UnitOfWork.Commit();
        }

        public async Task Alterar(AlunoCurso alunoCurso)
        {
            alunoCurso.Validar();

            var banco = await _alunoCursoRepository.ObterPorId(alunoCurso.Id);
            Validacoes.ValidarSeNulo(banco, "Vinculo não encontrado");

            _alunoCursoRepository.Alterar(alunoCurso);
            await _alunoCursoRepository.UnitOfWork.Commit();
        }

        public async Task Remover(Guid alunoCurso)
        {
            var info = await _alunoCursoRepository.ObterPorId(alunoCurso);
            Validacoes.ValidarSeNulo(info, "Vinculo não encontrado");

            _alunoCursoRepository.Remover(info);
            await _alunoCursoRepository.UnitOfWork.Commit();
        }
    }
}
