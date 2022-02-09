using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        public IEnumerable <Evento> _evento = new Evento[]{
              new Evento () {
              EventoId = 1,
              Tema = "Angular e Dotnet", 
              Local = "Belo Horizonte", 
              Lote = "1° Lote", 
              QtdPessoas = 250, 
              DataEvento = DateTime.Now.AddDays(2).ToString(), 
              ImageUrl = "foto.png"
            },
            new Evento () {
              EventoId = 2,
              Tema = "Novidades", 
              Local = "Belo Horizonte", 
              Lote = "4° Lote", 
              QtdPessoas = 350, 
              DataEvento = DateTime.Now.AddDays(4).ToString(), 
              ImageUrl = "foto2.png"
            }
          };

        public EventoController()
        {
    
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
          return _evento;
        }

         [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
          
          return _evento.Where(evento => evento.EventoId == id );
        }

        [HttpPost]
        public string Post()
        {
          return "return post method";
        }
        
        [HttpPut]
        public string Put()
        {
          return "return put method";
        }
    }
}