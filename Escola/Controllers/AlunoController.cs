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
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoServiceApp _alunoServiceApp;

        public AlunoController(IAlunoServiceApp alunoServiceApp)
        {
            _alunoServiceApp = alunoServiceApp;
        }
        /// <summary>
        ///  Adiciona um aluno
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Mensagem informativa </returns>
        [HttpPost("v1/Aluno/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] AlunoDto aluno)
        {
            await _alunoServiceApp.Adicionar(aluno);
            return Ok(ResultadoDto.Create(HttpStatusCode.OK, "Aluno cadastrado com sucesso"));
        }
        /// <summary>
        ///  Altera um aluno
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Mensagem informativa </returns>
        [HttpPut("v1/Aluno/Editar")]
        public async Task<IActionResult> Editar([FromBody] AlunoListDto aluno)
        {
            await _alunoServiceApp.Alterar(aluno);
            return Ok(ResultadoDto.Create(HttpStatusCode.OK, "Aluno alterado com sucesso"));
        }
        /// <summary>
        ///  Lista todos os alunos
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Mensagem informativa e lista todos os alunos seus respectivos cursos</returns>
        [HttpGet("v1/Aluno/ListarTodosAlunos")]
        public IActionResult ListarTodosAlunos()
        {
            var alunos = _alunoServiceApp.ListarTodosAlunos();
            return Ok(ResultadoDto.Create(HttpStatusCode.OK, "Lista de todos os alunos", alunos));
        }
        /// <summary>
        ///  Filtra um aluno especifico
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Mensagem informativa e lista aluno filtrado e seus respectivos cursos</returns>

        [HttpGet("v1/Aluno/ObterPorAlunoId")]
        public IActionResult ObterPorAlunoId(Guid alunoId)
        {
            var alunos = _alunoServiceApp.ObterPorId(alunoId);
            return Ok(ResultadoDto.Create(HttpStatusCode.OK, "Informações gerada com sucesso.", alunos));
        }
    }
}
