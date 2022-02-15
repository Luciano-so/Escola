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
    public class AlunoNotaRepository : IAlunoNotaRepository
    {
        private readonly EscolaContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public AlunoNotaRepository(EscolaContext context)
        {
            _context = context;
        }

        public async Task CadastrarNota(AlunoNota alunoNota)
        {
            Validation(alunoNota, EntityState.Added);
            await _context.AddAsync(alunoNota);
        }

        public void Alterar(AlunoNota alunoNota)
        {
            Validation(alunoNota, EntityState.Modified);
            _context.Entry(alunoNota).State = EntityState.Modified;
        }

        public IEnumerable<AlunoNota> ObterNotaPorAluno(Guid alunoId)
        {
            return _context.AlunoNota.AsNoTracking().Where(t => t.Id == alunoId);
        }

        public async Task<AlunoNota> ObterPorId(Guid alunoNota)
        {
            return await _context.AlunoNota.AsNoTracking().FirstOrDefaultAsync(t => t.Id == alunoNota);
        }


        public IEnumerable<AlunoNota> ObterTodasNotas()
        {
            return _context.AlunoNota.Include(t => t.AlunoCurso).AsNoTracking();
        }

        private void Validation(AlunoNota alunoNota, EntityState state)
        {
            ValidaSeExisteInformacoes(alunoNota);
            switch (state)
            {
                case EntityState.Added: ValidationAdded(alunoNota); break;
                case EntityState.Modified: ValidationModified(alunoNota); break;
            }
        }

        private void ValidationAdded(AlunoNota alunoNota)
        {
            Validacoes.ValidarSeVerdadeiro(_context.AlunoNota.AsNoTracking().Any(x => x.AlunoCursoId == alunoNota.AlunoCursoId &&
                                                                                      x.Bimeste == alunoNota.Bimeste), "Aluno não pode ter mais de uma nota por bimestre.");
        }

        private void ValidationModified(AlunoNota alunoNota)
        {
            Validacoes.ValidarSeVerdadeiro(_context.AlunoNota.AsNoTracking().Any(x => x.AlunoCursoId == alunoNota.AlunoCursoId &&
                                                                                      x.Bimeste == alunoNota.Bimeste &&
                                                                                      x.Id != alunoNota.Id), "Aluno não pode ter mais de uma nota por bimestre.");
        }

        private void ValidaSeExisteInformacoes(AlunoNota alunoNota)
        {
            Validacoes.ValidarSeFalso(_context.AlunoCurso.Any(t => t.Id == alunoNota.AlunoCursoId), "Vinculo não encontrado");
        }
    }
}
