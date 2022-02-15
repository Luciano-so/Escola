using Escola.Application.Services;
using Escola.Domain.Dtos;
using Escola.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Escola.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoCursoController : ControllerBase
    {
        private readonly IAlunoCursoServiceApp _alunoCursoServiceApp;

        public AlunoCursoController(IAlunoCursoServiceApp alunoCursoServiceApp)
        {
            _alunoCursoServiceApp = alunoCursoServiceApp;
        }

        /// <summary>
        /// Vincula um Aluno a um curso
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Mensagem informativa</returns>
        [HttpPost("v1/AlunoCurso/VincularCursoAluno")]
        public async Task<IActionResult> VincularCursoAluno([FromBody] AlunoCursoDto aluno)
        {
            await _alunoCursoServiceApp.Adiciona(aluno);
            return Ok(ResultadoDto.Create(HttpStatusCode.OK, "Vinculo cadastrado com sucesso"));
        }
        /// <summary>
        /// Altera vinculação de um Aluno a um curso desde que não tenha notas informadas
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Mensagem informativa</returns>

        [HttpPut("v1/AlunoCurso/EditarVinculoAlunoCurso")]
        public async Task<IActionResult> Editar([FromBody] AlunoCursoEditDto aluno)
        {
            await _alunoCursoServiceApp.Alterar(aluno);
            return Ok(ResultadoDto.Create(HttpStatusCode.OK, "Vinculo alterado com sucesso"));
        }
        /// <summary>
        /// Remove vinculação de um Aluno a um curso desde que não tenha notas informadas
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Mensagem informativa</returns>
        [HttpDelete("v1/AlunoCurso/RemoverVinculoAlunoCurso")]
        public async Task<IActionResult> RemoverVinculoAlunoCurso(Guid alunoCursoId)
        {
            await _alunoCursoServiceApp.Remover(alunoCursoId);
            return Ok(ResultadoDto.Create(HttpStatusCode.OK, "Vinculo removido com sucesso"));
        }
    }
}
