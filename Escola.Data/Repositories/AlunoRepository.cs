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
    public class AlunoRepository : IAlunoRepository
    {
        private readonly EscolaContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public AlunoRepository(EscolaContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Aluno aluno)
        {
            Validation(aluno, EntityState.Added);
            await _context.AddAsync(aluno);
        }

        public void Alterar(Aluno aluno)
        {
            Validation(aluno, EntityState.Modified);
            _context.Entry(aluno).State = EntityState.Modified;
        }

        public IEnumerable<Aluno> ListarTodosAlunos()
        {
            return _context.Aluno.AsNoTracking()
                           .Include(t => t.AlunoCurso).ThenInclude(t => t.AlunoNota)
                           .Include(t => t.AlunoCurso).ThenInclude(t => t.Curso)
                           .ToList();
        }

        public Aluno ObterPorId(Guid alunoId)
        {
            return _context.Aluno.AsNoTracking()
                           .Include(t => t.AlunoCurso).ThenInclude(t => t.AlunoNota)
                           .Include(t => t.AlunoCurso).ThenInclude(t => t.Curso)
                           .FirstOrDefault(t => t.Id == alunoId);
        }

        public bool ObterPorCpf(string cpf)
        {
            return _context.Aluno.AsNoTracking().Any(t => t.Cpf == cpf);
        }

        private void Validation(Aluno aluno, EntityState state)
        {
            switch (state)
            {
                case EntityState.Added: ValidationAdded(aluno); break;
                case EntityState.Modified: ValidationModified(aluno); break;
            }
        }

        private void ValidationAdded(Aluno aluno)
        {
            Validacoes.ValidarSeVerdadeiro(ObterPorCpf(aluno.Cpf), "Aluno não pode ter mais de um cadastro(CPF)");
        }

        private void ValidationModified(Aluno aluno)
        {
            Validacoes.ValidarSeVerdadeiro(_context.Aluno.AsNoTracking().Any(x => x.Cpf == aluno.Cpf && x.Id != aluno.Id), "CPF já Cadastrado");
        }
    }
}
