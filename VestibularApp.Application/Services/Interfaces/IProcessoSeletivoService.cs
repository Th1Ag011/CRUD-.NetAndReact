using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using VestibularApp.Application.Dtos.Reponse;
using VestibularApp.Application.Dtos.Request;
using VestibularApp.Domain.Entities;

namespace VestibularApp.Application.Services.Interfaces
{
    public interface IProcessoSeletivoService
    {
        Task<List<ProcessoSeletivoResponseDto>> GetAllResponseAsync();
        Task<ProcessoSeletivoResponseDto> GetResponseByIdAsync(Guid id);
        Task<ProcessoSeletivoResponseDto> CreateAsync(ProcessoSeletivoRequestDto dto);
        Task<ProcessoSeletivoResponseDto> UpdateAsync(Guid id, ProcessoSeletivoRequestDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
