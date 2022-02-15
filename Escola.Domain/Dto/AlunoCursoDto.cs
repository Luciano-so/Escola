using System;
using System.Collections.Generic;

namespace Escola.Domain.Entities
{
    public class AlunoCursoDto
    {
        public Guid AlunoId { get; set; }
        public Guid CursoId { get; set; }
    }
    public class AlunoCursoEditDto
    {
        public Guid Id { get; set; }
        public Guid AlunoId { get; set; }
        public Guid CursoId { get; set; }
    }
    public class AlunoCursoViewDto
    {
        public string Aluno { get; set; }
        public string Curso { get; set; }
    }

    public class AlunoCursoNotaDto
    {
        public string Curso { get; set; }
        public List<AlunoNotaListDto> Notas { get; set; }
    }
}
