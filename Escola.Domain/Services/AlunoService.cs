using Escola.Core.Entities;
using Escola.Domain.Contracts.IRepositorys;
using Escola.Domain.Contracts.IServices;
using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Domain.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task Adicionar(Aluno aluno)
        {
            aluno.Validar();

            await _alunoRepository.Adicionar(aluno);
            await _alunoRepository.UnitOfWork.Commit();
        }

        public async Task Alterar(Aluno aluno)
        {
            aluno.Validar();

            var banco = _alunoRepository.ObterPorId(aluno.Id);
            Validacoes.ValidarSeNulo(banco, "Aluno não encontrado");

            _alunoRepository.Alterar(aluno);
            await _alunoRepository.UnitOfWork.Commit();
        }

        public IEnumerable<Aluno> ListarTodosAlunos()
        {
            return _alunoRepository.ListarTodosAlunos();
        }
        public Aluno ObterPorId(Guid alunoId)
        {
            return _alunoRepository.ObterPorId(alunoId);
        }
    }
}
