using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VestibularApp.Application.Dtos.Request;
using VestibularApp.Application.Dtos.Reponse;
using VestibularApp.Application.Services.Interfaces;

namespace VestibularApp.API.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas a candidatos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {
        private readonly ICandidatoService _candidatoService;

        public CandidatoController(ICandidatoService candidatoService)
        {
            _candidatoService = candidatoService;
        }

        /// <summary>
        /// Retorna todos os candidatos cadastrados.
        /// </summary>
        /// <returns>Lista de candidatos.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidatoResponseDto>>> GetAll()
        {
            var response = await _candidatoService.GetAllResponseAsync();
            if (response is null || !response.Any())
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Retorna um candidato específico pelo ID.
        /// </summary>
        /// <param name="id">ID do candidato.</param>
        /// <returns>Dados do candidato.</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CandidatoResponseDto>> GetById(Guid id)
        {
            var response = await _candidatoService.GetResponseByIdAsync(id);
            if (response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Cria um novo candidato.
        /// </summary>
        /// <param name="dto">Dados do candidato a ser criado.</param>
        /// <returns>Candidato criado.</returns>
        [HttpPost]
        public async Task<ActionResult<CandidatoResponseDto>> Create([FromBody] CandidatoRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _candidatoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        /// <summary>
        /// Atualiza os dados de um candidato existente.
        /// </summary>
        /// <param name="id">ID do candidato.</param>
        /// <param name="dto">Dados atualizados do candidato.</param>
        /// <returns>Candidato atualizado.</returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CandidatoResponseDto>> Update(Guid id, [FromBody] UpdateCandidatoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _candidatoService.UpdateAsync(id, dto);
            if (response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Remove um candidato pelo ID.
        /// </summary>
        /// <param name="id">ID do candidato.</param>
        /// <returns>Status da operação.</returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var success = await _candidatoService.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return Ok(new { message = "Candidato deletado com sucesso." });
        }
    }
}
