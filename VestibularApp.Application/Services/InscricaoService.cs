using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VestibularApp.Application.Dtos.Request;
using VestibularApp.Application.Dtos.Reponse;
using VestibularApp.Application.Services.Interfaces;
using VestibularApp.Domain.Entities;
using VestibularApp.Domain.Interfaces;
using Mapster;

namespace VestibularApp.Application.Services
{
    public class InscricaoService : GenericService<Inscricao>, IInscricaoService
    {
        private readonly IInscricaoRepository _inscricaoRepository;

        public InscricaoService(IInscricaoRepository inscricaoRepository)
            : base(inscricaoRepository)
        {
            _inscricaoRepository = inscricaoRepository;
        }

        public async Task<List<InscricaoResponseDto>> GetAllResponseAsync()
        {
            var inscricoes = await GetAllAsync();
            return inscricoes.Adapt<List<InscricaoResponseDto>>();
        }

        public async Task<InscricaoResponseDto> GetResponseByIdAsync(Guid id)
        {
            var inscricao = await GetByIdAsync(id);
            return inscricao?.Adapt<InscricaoResponseDto>();
        }

        public async Task<InscricaoResponseDto> CreateAsync(InscricaoRequestDto dto)
        {
            var inscricao = dto.Adapt<Inscricao>();
            await AddAsync(inscricao);
            return inscricao.Adapt<InscricaoResponseDto>();
        }

        public async Task<InscricaoResponseDto> UpdateAsync(Guid id, InscricaoRequestDto dto)
        {
            var inscricao = await GetByIdAsync(id);
            if (inscricao is null)
            {
                return null;
            }

            dto.Adapt(inscricao);
            await UpdateAsync(inscricao);
            return inscricao.Adapt<InscricaoResponseDto>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var inscricao = await GetByIdAsync(id);
            if (inscricao == null)
            {
                return false;
            }
            await base.DeleteAsync(id);
            return true;
        }

        public async Task<List<InscricaoResponseDto>> GetByCandidatoCpfResponseAsync(string cpf)
        {
            var inscricoes = await _inscricaoRepository.GetByCandidatoCpfAsync(cpf);
            return inscricoes.Adapt<List<InscricaoResponseDto>>();
        }

        public async Task<List<InscricaoResponseDto>> GetByCursoIdResponseAsync(Guid cursoId)
        {
            var inscricoes = await _inscricaoRepository.GetByCursoIdAsync(cursoId);
            return inscricoes.Adapt<List<InscricaoResponseDto>>();
        }

        public async Task<IEnumerable<InscricaoProcessoResponseDto>> GetByCpfWithProcessoInfoAsync(string cpf)
        {
            var inscricoes = await _inscricaoRepository.GetByCandidatoCpfAsync(cpf);

            var result = inscricoes.Select(i => new InscricaoProcessoResponseDto
            {
                InscricaoId = i.Id,
                NumeroInscricao = i.NumeroInscricao,
                NomeCandidato = i.Candidato.Nome,
                StatusInscricao = i.Status,
                ProcessoSeletivoNome = i.ProcessoSeletivo.Nome,
                DataInscricao = i.Data,
                Status = i.Status
            });

            return result;
        }
    }
}
