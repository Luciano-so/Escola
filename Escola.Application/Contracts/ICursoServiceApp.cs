
using Escola.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Application.Services
{
    public interface ICursoServiceApp
    {
        Task Adicionar(CursoAddDto cursoDto);
        Task Alterar(CursoDto cursoDto);
        IEnumerable<CursoDto> ListarTodosCursos();
        IEnumerable<CursoeAlunoDto> ListarTodosCursoseAlunos();
    }
}
