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
    public class AlunoNotaController : ControllerBase
    {
        private readonly IAlunoNotaServiceApp _alunoNotaServiceApp;

        public AlunoNotaController(IAlunoNotaServiceApp alunoNotaServiceApp)
        {
            _alunoNotaServiceApp = alunoNotaServiceApp;
        }
        /// <summary>
        /// Adiciona uma nota ao aluno
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Mensagem informativa</returns>
        [HttpPost("v1/AlunoNota/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] AlunoNotaAddDto alunoNota)
        {
            await _alunoNotaServiceApp.CadastrarNota(alunoNota);
            return Ok(ResultadoDto.Create(HttpStatusCode.OK, "Nota cadastrada com sucesso"));
        }
        /// <summary>
        /// Altera uma nota do aluno
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Mensagem informativa</returns>

        [HttpPut("v1/AlunoNota/Editar")]
        public async Task<IActionResult> Editar([FromBody] AlunoNotaEditDto alunoNota)
        {
            await _alunoNotaServiceApp.Alterar(alunoNota);
            return Ok(ResultadoDto.Create(HttpStatusCode.OK, "Nota alterada com sucesso"));
        }

        /// <summary>
        /// Lista todas as notas de todos os alunos
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Mensagem informativa Lista todas as notas de todos os alunos</returns>

        [HttpGet("v1/AlunoNota/ObterTodasNotas")]
        public IActionResult ObterTodasNotas()
        {
            var alunos = _alunoNotaServiceApp.ObterTodasNotas();
            return Ok(ResultadoDto.Create(HttpStatusCode.OK, "Lista de todas as notas", alunos));
        }
    }
}
