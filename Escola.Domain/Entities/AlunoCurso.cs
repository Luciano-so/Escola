
using Escola.Core.Entities;
using Escola.Core.Entity;
using System;
using System.Collections.Generic;

namespace Escola.Domain.Entities
{
    public class AlunoCurso : Entity
    {
        public Guid AlunoId { get; private set; }
        public Aluno Aluno { get; set; }
        public Guid CursoId { get; private set; }
        public Curso Curso { get; set; }
        private readonly List<AlunoNota> _alunoNota;
        public IReadOnlyCollection<AlunoNota> AlunoNota => _alunoNota;
        public static class Factory
        {
            public static AlunoCurso Create(Guid alunoId, Guid cursoId)
            {
                return new AlunoCurso()
                {
                    CursoId = cursoId,
                    AlunoId = alunoId,
                };
            }
        }
        protected AlunoCurso()
        {
            _alunoNota = new List<AlunoNota>();
        }
        public override void Validar()
        {
            Validacoes.ValidarSeNulo(CursoId, "O campo Curso do aluno não pode estar vazio");
            Validacoes.ValidarSeIgual(CursoId, Guid.Empty, "O campo Curso do aluno não pode estar vazio");

            Validacoes.ValidarSeNulo(AlunoId, "O campo Aluno do aluno não pode estar vazio");
            Validacoes.ValidarSeIgual(AlunoId, Guid.Empty, "O campo Aluno do aluno não pode estar vazio");
        }
    }
}
