using Escola.Core.Data;
using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Domain.Contracts.IRepositorys
{
    public interface IAlunoRepository : IRepository
    {
        Task Adicionar(Aluno aluno);
        Aluno ObterPorId(Guid alunoId);
        IEnumerable<Aluno> ListarTodosAlunos();
        void Alterar(Aluno aluno);
    }
}
