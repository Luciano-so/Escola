
using Escola.Core.Entities;
using Escola.Core.Entity;
using System.Collections.Generic;

namespace Escola.Domain.Entities
{
    public class Aluno : Entity
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }

        private readonly List<AlunoCurso> _alunoCurso;
        public IReadOnlyCollection<AlunoCurso> AlunoCurso => _alunoCurso;

        public static class Factory
        {
            public static Aluno Create(string nome, string cpf)
            {
                return new Aluno()
                {
                    Nome = nome?.ToUpper()?.Trim(),
                    Cpf = cpf?.Trim(),
                };
            }
        }
        protected Aluno()
        {
            _alunoCurso = new List<AlunoCurso>();
        }
        public override void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do aluno não pode estar vazio");
            Validacoes.ValidarTamanho(Nome, 2, 100, "Nome deve ser conter de {0} a {1} caracteres");

            Validacoes.ValidarSeVazio(Cpf, "O CPF do aluno deve ser preenchido");
            Validacoes.ValidarCPF(Cpf, "O CPF do aluno  é inválido");
        }
    }
}
