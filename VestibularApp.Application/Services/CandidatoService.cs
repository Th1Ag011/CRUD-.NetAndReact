using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using VestibularApp.Application.Dtos.Request;
using VestibularApp.Application.Dtos.Reponse;
using VestibularApp.Application.Services.Interfaces;
using VestibularApp.Domain.Entities;
using VestibularApp.Domain.Interfaces;

namespace VestibularApp.Application.Services
{
    public class CandidatoService : GenericService<Candidato>, ICandidatoService
    {
        private readonly ICandidatoRepository _candidatoRepository;

        public CandidatoService(ICandidatoRepository candidatoRepository)
            : base(candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }

        public async Task<List<CandidatoResponseDto>> GetAllResponseAsync()
        {
            var candidatos = await GetAllAsync();
            return candidatos.Adapt<List<CandidatoResponseDto>>();
        }

        public async Task<CandidatoResponseDto> GetResponseByIdAsync(Guid id)
        {
            var candidato = await GetByIdAsync(id);
            return candidato?.Adapt<CandidatoResponseDto>();
        }

        public async Task<CandidatoResponseDto> CreateAsync(CandidatoRequestDto dto)
        {
            var candidato = dto.Adapt<Candidato>();
            await AddAsync(candidato);
            return candidato.Adapt<CandidatoResponseDto>();
        }

        public async Task<CandidatoResponseDto> UpdateAsync(Guid id, UpdateCandidatoDto dto)
        {
            var candidato = await GetByIdAsync(id);
            if (candidato == null)
            {
                return null;
            }

            dto.Adapt(candidato);
            await UpdateAsync(candidato);
            return candidato.Adapt<CandidatoResponseDto>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var candidato = await GetByIdAsync(id);
            if (candidato == null)
            {
                return false;
            }
            await base.DeleteAsync(id);
            return true;
        }
    }
}
