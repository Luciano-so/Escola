using System;

namespace Escola.Domain.Entities
{
    public class AlunoNotaAddDto
    {
        public Guid AlunoCursoId { get; set; }
        public decimal Nota { get; set; }
        public int Bimestre { get; set; }

    }
    public class AlunoNotaEditDto
    {
        public Guid Id { get; set; }
        public Guid AlunoCursoId { get; set; }
        public decimal Nota { get; set; }
        public int Bimestre { get; set; }
    }
    public class AlunoNotaAllDto
    {
        public Guid Id { get; set; }
        public string Aluno { get; set; }
        public string Cpf { get; set; }
        public string Curso { get; set; }
        public decimal Nota { get; set; }
        public int Bimestre { get; set; }
    }

    public class AlunoNotaListDto
    {
        public decimal Nota { get; set; }
        public int Bimestre { get; set; }
    }

}
