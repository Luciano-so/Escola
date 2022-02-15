using System;
using System.Collections.Generic;

namespace Escola.Domain.Entities
{
    public class CursoAddDto
    {
        public string Nome { get; set; }
    }
    public class CursoDto
    {
        public string Nome { get; set; }
        public Guid Id { get; set; }
    }
    public class CursoeAlunoDto
    {
        public string Nome { get; set; }
        public IEnumerable<AlunoCursoViewDto> Alunos { get; set; }
    }
}
