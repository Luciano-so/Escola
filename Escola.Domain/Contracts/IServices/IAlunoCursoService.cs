using Escola.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Escola.Domain.Contracts.IServices
{
    public interface IAlunoCursoService
    {
        Task Adiciona(AlunoCurso alunoCurso);
        Task Alterar(AlunoCurso alunoCurso);
        Task Remover(Guid alunoCurso);
    }
}
