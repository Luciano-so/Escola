using Escola.Application.Services;
using Escola.Domain.Dtos;
using Escola.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Escola.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoServiceApp _cursoServiceApp;

        public CursoController(ICursoServiceApp cursoServiceApp)
        {
            _cursoServiceApp = cursoServiceApp;
        }
        /// <summary>
        ///  Adiciona um novo curso
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Mensagem informativa</returns>
        [HttpPost("v1/Curso/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] CursoAddDto curso)
        {
            await _cursoServiceApp.Adicionar(curso);
            return Ok(ResultadoDto.Create(HttpStatusCode.OK, "Curso Adicionado com sucesso"));
        }
        /// <summary>
        ///  Altera um curso
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Mensagem informativa</returns>
        [HttpPut("v1/Curso/Editar")]
        public async Task<IActionResult> Editar([FromBody] CursoDto curso)
        {
            await _cursoServiceApp.Alterar(curso);
            return Ok(ResultadoDto.Create(HttpStatusCode.OK, "Curso Alteraco com sucesso"));
        }
        /// <summary>
        ///  Lista todos os cursos
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Mensagem informativa </returns>
        [HttpGet("v1/Curso/ListarTodosCursos")]
        public IActionResult ListarTodosCursos()
        {
            var info = _cursoServiceApp.ListarTodosCursos();
            return Ok(ResultadoDto.Create(HttpStatusCode.OK, "Lista de todos os cursos", info));
        }

        /// <summary>
        ///  Lista todos os cursos com Alunos
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Mensagem informativa e Lista de cursos com alunos</returns>
        [HttpGet("v1/Curso/ListarTodosCursoseAlunos")]
        public IActionResult ListarTodosCursoseAlunos()
        {
            var info = _cursoServiceApp.ListarTodosCursoseAlunos();
            return Ok(ResultadoDto.Create(HttpStatusCode.OK, "Lista de todos os cursos e alunos", info));
        }
    }
}
