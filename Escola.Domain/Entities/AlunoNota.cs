using Escola.Core.Entities;
using Escola.Core.Entity;
using System;

namespace Escola.Domain.Entities
{
    public class AlunoNota : Entity
    {
        public Guid AlunoCursoId { get; private set; }
        public AlunoCurso AlunoCurso { get; private set; }
        public int Bimeste { get; private set; }
        public decimal Nota { get; private set; }

        public static class Factory
        {
            public static AlunoNota Create(Guid alunoCursoId, int bimestre, decimal nota)
            {
                return new AlunoNota()
                {
                    AlunoCursoId = alunoCursoId,
                    Bimeste = bimestre,
                    Nota = nota
                };
            }
        }
        public override void Validar()
        {
            Validacoes.ValidarSeNulo(AlunoCursoId, "O campo Curso não pode estar vazio");
            Validacoes.ValidarSeIgual(AlunoCursoId, Guid.Empty, "O campo Curso não pode estar vazio");

            Validacoes.ValidarSeNulo(Nota, "O campo Nota não pode estar vazio");
            Validacoes.ValidarMinimoMaximo(Nota, 0, 10, "Nota deve ser maior que 0 e menor que 10");

            Validacoes.ValidarSeNulo(Bimeste, "O campo Bimestre não pode estar vazio");
            Validacoes.ValidarMinimoMaximo(Bimeste, 1, 6, "Bimestre deve ser maior que 1 e menor que 6");
        }
    }
}
