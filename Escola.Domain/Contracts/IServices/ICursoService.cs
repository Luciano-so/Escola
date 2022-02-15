using Escola.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Domain.Contracts.IServices
{
    public interface ICursoService
    {
        Task Adicionar(Curso curso);
        Task Alterar(Curso curso);
        IEnumerable<Curso> ListarTodosCursos();
        IEnumerable<Curso> ListarTodosCursoseAlunos();
    }
}
