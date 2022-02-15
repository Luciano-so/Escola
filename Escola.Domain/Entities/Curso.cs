using Escola.Core.Entities;
using Escola.Core.Entity;
using System.Collections.Generic;

namespace Escola.Domain.Entities
{
    public class Curso : Entity
    {
        public string Nome { get; private set; }

        private readonly List<AlunoCurso> _alunoCurso;
        public IReadOnlyCollection<AlunoCurso> AlunoCurso => _alunoCurso;
        public static class Factory
        {
            public static Curso Create(string nome)
            {
                return new Curso()
                {
                    Nome = nome?.ToUpper()?.Trim(),
                };
            }
        }
        protected Curso()
        {
            _alunoCurso = new List<AlunoCurso>();
        }
        public override void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Curso não pode estar vazio");
            Validacoes.ValidarTamanho(Nome, 2, 100, "Nome deve ser conter de 2 a 100 caracteres");
        }
    }
}
