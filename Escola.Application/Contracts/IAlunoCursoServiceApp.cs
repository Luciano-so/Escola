
using Escola.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Escola.Application.Services
{
    public interface IAlunoCursoServiceApp
    {
        Task Adiciona(AlunoCursoDto alunoCursoDto);
        Task Alterar(AlunoCursoEditDto alunoCursoDto);
        Task Remover(Guid alunoCurso);
    }
}
