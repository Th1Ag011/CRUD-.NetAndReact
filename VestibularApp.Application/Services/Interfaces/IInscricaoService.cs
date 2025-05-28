using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VestibularApp.Application.Dtos.Reponse;
using VestibularApp.Application.Dtos.Request;

namespace VestibularApp.Application.Services.Interfaces
{
    public interface IInscricaoService
    {
        Task<List<InscricaoResponseDto>> GetAllResponseAsync();
        Task<InscricaoResponseDto> GetResponseByIdAsync(Guid id);
        Task<InscricaoResponseDto> CreateAsync(InscricaoRequestDto dto);
        Task<InscricaoResponseDto> UpdateAsync(Guid id, InscricaoRequestDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<List<InscricaoResponseDto>> GetByCandidatoCpfResponseAsync(string cpf);
        Task<List<InscricaoResponseDto>> GetByCursoIdResponseAsync(Guid cursoId);
        Task<IEnumerable<InscricaoProcessoResponseDto>> GetByCpfWithProcessoInfoAsync(string cpf);
    }
}
