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
    /// Controlador para operações relacionadas a Cursos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        /// <summary>
        /// Inicializa uma nova instância do controller de Curso.
        /// </summary>
        /// <param name="cursoService">Serviço de Curso injetado.</param>
        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        /// <summary>
        /// Retorna todos os cursos cadastrados.
        /// </summary>
        /// <returns>Uma lista de objetos CursoResponseDto.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CursoResponseDto>>> GetAll()
        {
            var response = await _cursoService.GetAllResponseAsync();
            if (response is null || !response.Any())
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Retorna os detalhes de um curso pelo ID.
        /// </summary>
        /// <param name="id">ID do curso.</param>
        /// <returns>Um objeto CursoResponseDto com os detalhes do curso.</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CursoResponseDto>> GetById(Guid id)
        {
            var response = await _cursoService.GetResponseByIdAsync(id);
            if (response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Cria um novo curso.
        /// </summary>
        /// <param name="dto">Objeto CursoRequestDto contendo os dados do curso a ser criado.</param>
        /// <returns>O curso criado com status 201 e a URL para consulta.</returns>
        [HttpPost]
        public async Task<ActionResult<CursoResponseDto>> Create([FromBody] CursoRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _cursoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        /// <summary>
        /// Atualiza os dados de um curso existente.
        /// </summary>
        /// <param name="id">ID do curso.</param>
        /// <param name="dto">Objeto CursoRequestDto contendo os dados atualizados.</param>
        /// <returns>O curso atualizado.</returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CursoResponseDto>> Update(Guid id, [FromBody] CursoRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _cursoService.UpdateAsync(id, dto);
            if (response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Exclui um curso pelo ID.
        /// </summary>
        /// <param name="id">ID do curso.</param>
        /// <returns>Status da operação com uma mensagem de sucesso.</returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var success = await _cursoService.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return Ok(new { message = "Curso deletado com sucesso." });
        }
    }
}
