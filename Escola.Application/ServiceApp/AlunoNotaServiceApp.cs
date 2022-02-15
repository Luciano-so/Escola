using AutoMapper;
using Escola.Domain.Contracts.IServices;
using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Application.Services
{
    public class AlunoNotaServiceApp : IAlunoNotaServiceApp
    {
        private readonly IMapper _mapper;
        private readonly IAlunoNotaService _alunoNotaService;

        public AlunoNotaServiceApp(IMapper mapper, IAlunoNotaService alunoService) => (_mapper, _alunoNotaService) = (mapper, alunoService);
        public async Task CadastrarNota(AlunoNotaAddDto alunoNotaDto)
        {
            var alunoNota = _mapper.Map<AlunoNota>(alunoNotaDto);
            await _alunoNotaService.CadastrarNota(alunoNota);
        }
        public async Task Alterar(AlunoNotaEditDto alunoNotaDto)
        {
            var alunoNota = _mapper.Map<AlunoNota>(alunoNotaDto);
            alunoNota.Id = alunoNotaDto.Id;
            await _alunoNotaService.Alterar(alunoNota);
        }

        public IEnumerable<AlunoNota> ObterNotaPorAluno(Guid alunoId)
        {
            return _alunoNotaService.ObterNotaPorAluno(alunoId);
        }

        public IEnumerable<AlunoNotaAllDto> ObterTodasNotas()
        {
            var alunoNota = _mapper.Map<IEnumerable<AlunoNotaAllDto>>(_alunoNotaService.ObterTodasNotas());
            return alunoNota;
        }
    }
}
