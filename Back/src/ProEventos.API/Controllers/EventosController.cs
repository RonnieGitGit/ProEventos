using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Application.Contratos;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {


        private readonly IEventoService iEventoService;

        public EventosController(IEventoService iEventoService)
        {
            this.iEventoService = iEventoService;

        }

        [HttpGet]
        
        //IActionResult ele permite retornar os resultados do http: status 200, 404, entre outros
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await iEventoService.GetAllEventosAsync(true);
                if(eventos == null) return NotFound("Nenhum evento encontrado");
                return Ok(eventos); //ok é 200
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,  "Erro ao tentar recuperar eventos. Erro: {ex.message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await iEventoService.GetEventoByIdAsync(id, true);
                if(evento == null) return NotFound("Nenhum encontrado");
                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,  "Erro ao tentar recuperar eventos. Erro: { ex.message}");
            }
        }

        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var evento = await iEventoService.GetAllEventosByTemaAsync(tema, true);
                if(evento == null) return NotFound("Nenhum encontrado");
                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,  "Erro ao tentar recuperar eventos. Erro: { ex.message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var evento = await iEventoService.AddEvento(model);
                if(evento == null) return BadRequest("Erro ao tentar adicionar evento.");
                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,  "Erro ao tentar recuperar eventos. Erro: { ex.message}");
            }
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = await iEventoService.UpdateEvento(id, model);
                if(evento == null) return BadRequest("Erro a.");
                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,  "Erro ao tentar recuperar eventos. Erro: { ex.message}");
            }
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
              return await iEventoService.DeleteEvento(id) ? 
              Ok("Deletado") : 
              BadRequest("Evento não deletado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,  "Erro ao tentar recuperar eventos. Erro: { ex.message}");
            }
        }

        
    }
}