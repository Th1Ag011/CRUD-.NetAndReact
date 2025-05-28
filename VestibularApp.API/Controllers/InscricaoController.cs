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
    /// Controlador para operações relacionadas a Inscrições.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InscricaoController : ControllerBase
    {
        private readonly IInscricaoService _inscricaoService;

        /// <summary>
        /// Inicializa uma nova instância do InscricaoController.
        /// </summary>
        /// <param name="inscricaoService">Serviço de Inscrição injetado.</param>
        public InscricaoController(IInscricaoService inscricaoService)
        {
            _inscricaoService = inscricaoService;
        }

        /// <summary>
        /// Retorna todas as inscrições cadastradas.
        /// </summary>
        /// <returns>Uma lista de InscricaoResponseDto.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InscricaoResponseDto>>> GetAll()
        {
            var response = await _inscricaoService.GetAllResponseAsync();
            if (response is null || !response.Any())
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Retorna os detalhes de uma inscrição pelo ID.
        /// </summary>
        /// <param name="id">ID da inscrição.</param>
        /// <returns>Um objeto InscricaoResponseDto.</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<InscricaoResponseDto>> GetById(Guid id)
        {
            var response = await _inscricaoService.GetResponseByIdAsync(id);
            if (response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Cria uma nova inscrição.
        /// </summary>
        /// <param name="dto">Objeto InscricaoRequestDto com os dados da inscrição.</param>
        /// <returns>A inscrição criada com status 201 e a URL para consulta.</returns>
        [HttpPost]
        public async Task<ActionResult<InscricaoResponseDto>> Create([FromBody] InscricaoRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _inscricaoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        /// <summary>
        /// Atualiza os dados de uma inscrição existente.
        /// </summary>
        /// <param name="id">ID da inscrição.</param>
        /// <param name="dto">Objeto InscricaoRequestDto com os dados atualizados.</param>
        /// <returns>A inscrição atualizada.</returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<InscricaoResponseDto>> Update(Guid id, [FromBody] InscricaoRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _inscricaoService.UpdateAsync(id, dto);
            if (response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Exclui uma inscrição pelo ID.
        /// </summary>
        /// <param name="id">ID da inscrição.</param>
        /// <returns>Status da operação com uma mensagem de sucesso.</returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var success = await _inscricaoService.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return Ok(new { message = "Inscrição deletada com sucesso." });
        }

        /// <summary>
        /// Retorna as inscrições de um candidato filtradas pelo CPF.
        /// </summary>
        /// <param name="cpf">CPF do candidato.</param>
        /// <returns>Uma lista de InscricaoResponseDto.</returns>
        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<IEnumerable<InscricaoResponseDto>>> GetByCandidatoCpf(string cpf)
        {
            var response = await _inscricaoService.GetByCandidatoCpfResponseAsync(cpf);
            return Ok(response);
        }

        /// <summary>
        /// Retorna as inscrições associadas a um curso pelo ID do curso.
        /// </summary>
        /// <param name="cursoId">ID do curso.</param>
        /// <returns>Uma lista de InscricaoResponseDto.</returns>
        [HttpGet("curso/{cursoId:guid}")]
        public async Task<ActionResult<IEnumerable<InscricaoResponseDto>>> GetByCursoId(Guid cursoId)
        {
            var response = await _inscricaoService.GetByCursoIdResponseAsync(cursoId);
            return Ok(response);
        }

        /// <summary>
        /// Retorna inscrições com informações do processo seletivo, filtradas pelo CPF do candidato.
        /// </summary>
        /// <param name="cpf">CPF do candidato.</param>
        /// <returns>Uma lista de InscricaoProcessoResponseDto.</returns>
        [HttpGet("inscricaoWithProcess/{cpf}")]
        public async Task<ActionResult<IEnumerable<InscricaoProcessoResponseDto>>> GetByCpfWithProcessInfo(string cpf)
        {
            var result = await _inscricaoService.GetByCpfWithProcessoInfoAsync(cpf);
            return Ok(result);
        }
    }
}
