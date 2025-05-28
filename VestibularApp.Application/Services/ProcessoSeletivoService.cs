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
    public class ProcessoSeletivoService : GenericService<ProcessoSeletivo>, IProcessoSeletivoService
    {
        private readonly IProcessoSeletivoRepository _processoSeletivoRepository;

        public ProcessoSeletivoService(IProcessoSeletivoRepository repository)
            : base(repository)
        {
            _processoSeletivoRepository = repository;
        }

        public async Task<List<ProcessoSeletivoResponseDto>> GetAllResponseAsync()
        {
            var processos = await GetAllAsync();
            return processos.Adapt<List<ProcessoSeletivoResponseDto>>();
        }

        public async Task<ProcessoSeletivoResponseDto> GetResponseByIdAsync(Guid id)
        {
            var processo = await GetByIdAsync(id);
            return processo?.Adapt<ProcessoSeletivoResponseDto>();
        }

        public async Task<ProcessoSeletivoResponseDto> CreateAsync(ProcessoSeletivoRequestDto dto)
        {
            var processo = dto.Adapt<ProcessoSeletivo>();
            await AddAsync(processo);
            return processo.Adapt<ProcessoSeletivoResponseDto>();
        }

        public async Task<ProcessoSeletivoResponseDto> UpdateAsync(Guid id, ProcessoSeletivoRequestDto dto)
        {
            var processo = await GetByIdAsync(id);
            if (processo == null)
            {
                return null;
            }
            dto.Adapt(processo);
            await UpdateAsync(processo);
            return processo.Adapt<ProcessoSeletivoResponseDto>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var processo = await GetByIdAsync(id);
            if (processo == null)
            {
                return false;
            }
            await base.DeleteAsync(id);
            return true;
        }
    }
}
