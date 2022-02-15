using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Domain.Contracts.IServices
{
    public interface IAlunoService
    {
        Task Adicionar(Aluno aluno);
        Task Alterar(Aluno aluno);
        IEnumerable<Aluno> ListarTodosAlunos();
        Aluno ObterPorId(Guid alunoId);
    }
}
