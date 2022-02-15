
using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Application.Services
{
    public interface IAlunoNotaServiceApp
    {
        Task CadastrarNota(AlunoNotaAddDto alunoNota);
        Task Alterar(AlunoNotaEditDto alunoNota);
        IEnumerable<AlunoNota> ObterNotaPorAluno(Guid alunoId);
        IEnumerable<AlunoNotaAllDto> ObterTodasNotas();
    }
}
