using Escola.Core.Data;
using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Domain.Contracts.IRepositorys
{
    public interface ICursoRepository : IRepository
    {
        Task Adicionar(Curso curso);
        void Alterar(Curso curso);
        IEnumerable<Curso> ListarTodosCursos();
        IEnumerable<Curso> ListarTodosCursoseAlunos();
        Task<Curso> ObterPorId(Guid cursoId);
    }
}
