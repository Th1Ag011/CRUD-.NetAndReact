using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using VestibularApp.Application.Dtos.Reponse;
using VestibularApp.Application.Dtos.Request;
using VestibularApp.Domain.Entities;

namespace VestibularApp.Application.Services.Interfaces
{
    public interface ICandidatoService
    {
        Task<List<CandidatoResponseDto>> GetAllResponseAsync();
        Task<CandidatoResponseDto> GetResponseByIdAsync(Guid id);
        Task<CandidatoResponseDto> CreateAsync(CandidatoRequestDto dto);
        Task<CandidatoResponseDto> UpdateAsync(Guid id, UpdateCandidatoDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
