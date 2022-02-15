using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Domain.Contracts.IServices
{
    public interface IAlunoNotaService
    {
        Task CadastrarNota(AlunoNota alunoNota);
        Task Alterar(AlunoNota alunoNota);
        IEnumerable<AlunoNota> ObterNotaPorAluno(Guid alunoId);
        IEnumerable<AlunoNota> ObterTodasNotas();
    }
}
