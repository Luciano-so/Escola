using AutoMapper;
using Escola.Domain.Contracts.IServices;
using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Application.Services
{
    public class AlunoServiceApp : IAlunoServiceApp
    {
        private readonly IMapper _mapper;
        private readonly IAlunoService _alunoService;

        public AlunoServiceApp(IMapper mapper, IAlunoService alunoService) => (_mapper, _alunoService) = (mapper, alunoService);

        public async Task Adicionar(AlunoDto alunoDto)
        {
            var aluno = _mapper.Map<Aluno>(alunoDto);
            await _alunoService.Adicionar(aluno);
        }

        public async Task Alterar(AlunoListDto alunoDto)
        {
            var aluno = _mapper.Map<Aluno>(alunoDto);
            aluno.Id = alunoDto.Id;
            await _alunoService.Alterar(aluno);
        }

        public IEnumerable<AlunoViewDto> ListarTodosAlunos()
        {
            var info = _alunoService.ListarTodosAlunos();
            return _mapper.Map<IEnumerable<AlunoViewDto>>(info);
        }

        public AlunoViewDto ObterPorId(Guid alunoId)
        {
            return _mapper.Map<AlunoViewDto>(_alunoService.ObterPorId(alunoId));
        }
    }
}
