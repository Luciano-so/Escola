using Escola.Core.Entities;
using Escola.Domain.Contracts.IRepositorys;
using Escola.Domain.Contracts.IServices;
using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Domain.Services
{
    public class AlunoNotaService : IAlunoNotaService
    {
        private readonly IAlunoNotaRepository _alunoNotaRepository;

        public AlunoNotaService(IAlunoNotaRepository alunoNotaRepository)
        {
            _alunoNotaRepository = alunoNotaRepository;
        }

        public async Task Alterar(AlunoNota alunoNota)
        {
            alunoNota.Validar();

            var banco = await _alunoNotaRepository.ObterPorId(alunoNota.Id);
            Validacoes.ValidarSeNulo(banco, "Nota não encontrada");

            _alunoNotaRepository.Alterar(alunoNota);
            await _alunoNotaRepository.UnitOfWork.Commit();
        }

        public async Task CadastrarNota(AlunoNota alunoNota)
        {
            alunoNota.Validar();

            await _alunoNotaRepository.CadastrarNota(alunoNota);
            await _alunoNotaRepository.UnitOfWork.Commit();
        }

        public IEnumerable<AlunoNota> ObterNotaPorAluno(Guid alunoId)
        {
            return _alunoNotaRepository.ObterNotaPorAluno(alunoId);
        }

        public IEnumerable<AlunoNota> ObterTodasNotas()
        {
            return _alunoNotaRepository.ObterTodasNotas();
        }
    }
}
