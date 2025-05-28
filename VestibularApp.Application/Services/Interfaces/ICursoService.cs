using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using VestibularApp.Application.Dtos.Request;
using VestibularApp.Domain.Entities;
using VestibularApp.Application.Dtos.Reponse;

namespace VestibularApp.Application.Services.Interfaces
{
    public interface ICursoService 
    {
        Task<List<CursoResponseDto>> GetAllResponseAsync();
        Task<CursoResponseDto> GetResponseByIdAsync(Guid id);
        Task<CursoResponseDto> CreateAsync(CursoRequestDto dto);
        Task<CursoResponseDto> UpdateAsync(Guid id, CursoRequestDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
