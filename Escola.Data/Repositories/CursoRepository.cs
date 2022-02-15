using Escola.Core.Data;
using Escola.Core.Entities;
using Escola.Domain.Contracts.IRepositorys;
using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly EscolaContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public CursoRepository(EscolaContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Curso curso)
        {
            Validation(curso, EntityState.Added);
            await _context.AddAsync(curso);
        }

        public void Alterar(Curso curso)
        {
            Validation(curso, EntityState.Modified);
            _context.Entry(curso).State = EntityState.Modified;
        }

        public IEnumerable<Curso> ListarTodosCursos()
        {
            return _context.Curso.AsNoTracking().ToList();
        }

        public async Task<Curso> ObterPorId(Guid cursoId)
        {
            return await _context.Curso.AsNoTracking().FirstOrDefaultAsync(t => t.Id == cursoId);
        }

        public IEnumerable<Curso> ListarTodosCursoseAlunos()
        {
            return _context.Curso.Include(t => t.AlunoCurso).ThenInclude(t => t.Aluno).AsNoTracking().ToList();
        }

        private void Validation(Curso curso, EntityState state)
        {
            switch (state)
            {
                case EntityState.Added: ValidationAdded(curso); break;
                case EntityState.Modified: ValidationModified(curso); break;
            }
        }

        private void ValidationAdded(Curso curso)
        {
            Validacoes.ValidarSeVerdadeiro(_context.Curso.AsNoTracking().Any(x => x.Nome == curso.Nome.Trim().ToUpper()), "Curso já cadastrado");
        }

        private void ValidationModified(Curso curso)
        {
            Validacoes.ValidarSeVerdadeiro(_context.Curso.AsNoTracking().Any(x => x.Nome == curso.Nome.Trim().ToUpper() && x.Id != curso.Id), "Curso já cadastrado");
        }
    }
}
