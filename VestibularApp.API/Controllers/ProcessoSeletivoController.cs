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
    /// Controlador para operações relacionadas a Processos Seletivos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoSeletivoController : ControllerBase
    {
        private readonly IProcessoSeletivoService _processoSeletivoService;

        /// <summary>
        /// Inicializa uma nova instância do ProcessoSeletivoController.
        /// </summary>
        /// <param name="processoSeletivoService">Serviço de Processo Seletivo injetado.</param>
        public ProcessoSeletivoController(IProcessoSeletivoService processoSeletivoService)
        {
            _processoSeletivoService = processoSeletivoService;
        }

        /// <summary>
        /// Retorna todos os processos seletivos cadastrados.
        /// </summary>
        /// <returns>Uma lista de ProcessoSeletivoResponseDto.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcessoSeletivoResponseDto>>> GetAll()
        {
            var response = await _processoSeletivoService.GetAllResponseAsync();
            if (response is null || !response.Any())
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Retorna os detalhes de um processo seletivo pelo ID.
        /// </summary>
        /// <param name="id">ID do processo seletivo.</param>
        /// <returns>Um objeto ProcessoSeletivoResponseDto.</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProcessoSeletivoResponseDto>> GetById(Guid id)
        {
            var response = await _processoSeletivoService.GetResponseByIdAsync(id);
            if (response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Cria um novo processo seletivo.
        /// </summary>
        /// <param name="dto">Objeto ProcessoSeletivoRequestDto com os dados do processo.</param>
        /// <returns>O processo seletivo criado com status 201 e a URL para consulta.</returns>
        [HttpPost]
        public async Task<ActionResult<ProcessoSeletivoResponseDto>> Create([FromBody] ProcessoSeletivoRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _processoSeletivoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        /// <summary>
        /// Atualiza os dados de um processo seletivo existente.
        /// </summary>
        /// <param name="id">ID do processo seletivo.</param>
        /// <param name="dto">Objeto ProcessoSeletivoRequestDto com os dados atualizados.</param>
        /// <returns>O processo seletivo atualizado.</returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProcessoSeletivoResponseDto>> Update(Guid id, [FromBody] ProcessoSeletivoRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _processoSeletivoService.UpdateAsync(id, dto);
            if (response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Exclui um processo seletivo pelo ID.
        /// </summary>
        /// <param name="id">ID do processo seletivo.</param>
        /// <returns>Status da operação com uma mensagem de sucesso.</returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var success = await _processoSeletivoService.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return Ok(new { message = "Processo Seletivo deletado com sucesso." });
        }
    }
}
