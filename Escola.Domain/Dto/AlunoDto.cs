using System;
using System.Collections.Generic;

namespace Escola.Domain.Entities
{
    public class AlunoDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
    public class AlunoListDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Guid Id { get; set; }
    }

    public class AlunoViewDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Guid Id { get; set; }
        public List<AlunoCursoNotaDto> Cursos { get; set; }
    }
}
