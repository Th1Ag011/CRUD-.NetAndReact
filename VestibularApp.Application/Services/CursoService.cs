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
    public class CursoService : GenericService<Curso>, ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository repository)
            : base(repository)
        {
            _cursoRepository = repository;
        }

        public async Task<List<CursoResponseDto>> GetAllResponseAsync()
        {
            var cursos = await GetAllAsync();
            return cursos.Adapt<List<CursoResponseDto>>();
        }

        public async Task<CursoResponseDto> GetResponseByIdAsync(Guid id)
        {
            var curso = await GetByIdAsync(id);
            return curso?.Adapt<CursoResponseDto>();
        }

        public async Task<CursoResponseDto> CreateAsync(CursoRequestDto dto)
        {
            var curso = dto.Adapt<Curso>();
            await AddAsync(curso);
            return curso.Adapt<CursoResponseDto>();
        }

        public async Task<CursoResponseDto> UpdateAsync(Guid id, CursoRequestDto dto)
        {
            var curso = await GetByIdAsync(id);
            if (curso == null)
            {
                return null;
            }
            dto.Adapt(curso);
            await UpdateAsync(curso);
            return curso.Adapt<CursoResponseDto>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var curso = await GetByIdAsync(id);
            if (curso == null)
            {
                return false;
            }
            await base.DeleteAsync(id);
            return true;
        }
    }
}
