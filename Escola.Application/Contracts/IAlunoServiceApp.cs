
using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Application.Services
{
    public interface IAlunoServiceApp
    {
        Task Adicionar(AlunoDto alunoDto);
        Task Alterar(AlunoListDto alunoDto);
        IEnumerable<AlunoViewDto> ListarTodosAlunos();
        AlunoViewDto ObterPorId(Guid alunoId);
    }
}
