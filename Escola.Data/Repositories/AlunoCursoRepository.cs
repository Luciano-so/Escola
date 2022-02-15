using Escola.Core.Data;
using Escola.Core.Entities;
using Escola.Domain.Contracts.IRepositorys;
using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Data.Repositories
{
    public class AlunoCursoRepository : IAlunoCursoRepository
    {
        private readonly EscolaContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public AlunoCursoRepository(EscolaContext context)
        {
            _context = context;
        }

        public async Task Adicionar(AlunoCurso alunoCurso)
        {
            Validation(alunoCurso, EntityState.Added);
            await _context.AddAsync(alunoCurso);
        }

        public void Alterar(AlunoCurso alunoCurso)
        {
            Validation(alunoCurso, EntityState.Modified);
            _context.Update(alunoCurso);
        }

        public void Remover(AlunoCurso alunoCurso)
        {
            Validation(alunoCurso, EntityState.Deleted);
            _context.Remove(alunoCurso);
        }

        private void Validation(AlunoCurso alunoCurso, EntityState state)
        {
            ValidaSeExisteInformacoes(alunoCurso);
            switch (state)
            {
                case EntityState.Added: ValidationAdded(alunoCurso); break;
                case EntityState.Modified: ValidationModified(alunoCurso); break;
                case EntityState.Deleted: ValidationDeleted(alunoCurso); break;
            }
        }

        public async Task<AlunoCurso> ObterPorId(Guid alunoCurso)
        {
            return await _context.AlunoCurso.AsNoTracking().Include(t => t.Aluno).Include(t => t.Curso).FirstOrDefaultAsync(t => t.Id == alunoCurso);
        }

        private void ValidationAdded(AlunoCurso alunoCurso)
        {
            Validacoes.ValidarSeVerdadeiro(_context.AlunoCurso.Any(r => r.AlunoId == alunoCurso.AlunoId), "Aluno não pode ter mais de um curso cadastrado");
        }

        private void ValidationModified(AlunoCurso alunoCurso)
        {
            Validacoes.ValidarSeVerdadeiro(_context.AlunoCurso.Any(r => r.AlunoId == alunoCurso.AlunoId && r.Id != alunoCurso.Id), "Aluno não pode ter mais de um curso cadastrado");
            Validacoes.ValidarSeVerdadeiro(_context.AlunoNota.Any(t => t.AlunoCursoId == alunoCurso.Id), "Aluno vinculado a uma Nota e não pode ser alterado");
        }

        private void ValidationDeleted(AlunoCurso alunoCurso)
        {
            Validacoes.ValidarSeVerdadeiro(_context.AlunoNota.Any(t => t.AlunoCursoId == alunoCurso.Id), "Aluno vinculado a uma Nota e não pode ser alterado");
        }

        private void ValidaSeExisteInformacoes(AlunoCurso alunoCurso)
        {
            Validacoes.ValidarSeFalso(_context.Curso.Any(t => t.Id == alunoCurso.CursoId), "Curso não encontrado");
            Validacoes.ValidarSeFalso(_context.Aluno.Any(t => t.Id == alunoCurso.AlunoId), "Aluno não encontrado");
            Validacoes.ValidarSeVerdadeiro(_context.AlunoNota.Any(t => t.AlunoCursoId == alunoCurso.Id), "Aluno vinculado a uma Nota e não pode ser alterado");
        }
    }
}
