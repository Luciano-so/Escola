using Escola.Core.Data;
using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Domain.Contracts.IRepositorys
{
    public interface IAlunoNotaRepository : IRepository
    {
        Task CadastrarNota(AlunoNota alunoNota);
        Task<AlunoNota> ObterPorId(Guid alunoNota);
        void Alterar(AlunoNota alunoNota);
        IEnumerable<AlunoNota> ObterNotaPorAluno(Guid alunoId);
        IEnumerable<AlunoNota> ObterTodasNotas();
    }
}
