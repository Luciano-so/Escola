using Escola.Core.Data;
using Escola.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Escola.Domain.Contracts.IRepositorys
{
    public interface IAlunoCursoRepository : IRepository
    {
        Task Adicionar(AlunoCurso alunoCurso);
        void Alterar(AlunoCurso alunoCurso);
        void Remover(AlunoCurso alunoCurso);
        Task<AlunoCurso> ObterPorId(Guid alunoCurso);
    }
}
