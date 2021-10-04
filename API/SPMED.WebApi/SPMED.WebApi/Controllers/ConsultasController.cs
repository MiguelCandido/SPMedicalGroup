using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPMED.WebApi.Domains;
using SPMED.WebApi.Interfaces;
using SPMED.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMED.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();

        }

        [HttpGet]
        public IActionResult Listar()
        {
            List<Consultum> listaConsulta = _consultaRepository.Listar();

            return Ok(listaConsulta);
        }

        [HttpGet("{idConsulta}")]
        public IActionResult BuscarPorID(int idConsulta)
        {
            try
            {
                Consultum teste = _consultaRepository.BuscarPorID(idConsulta);
                if (teste != null)
                {
                    return Ok(teste);
                }
                return NotFound("A consulta não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [HttpPost]
        public IActionResult Cadastrar(Consultum consulta)
        {

            try
            {
                _consultaRepository.Cadastrar(consulta);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
           
        }

        [HttpPut("{idConsulta}")]
        public IActionResult Atualizar(int idConsulta, Consultum consultaUPDT)
        {
            try
            {
                Consultum teste = _consultaRepository.BuscarPorID(idConsulta);
                if (teste != null)
                {
                    _consultaRepository.Atualizar(idConsulta, consultaUPDT);

                    return StatusCode(204);
                }

                return NotFound("A consulta não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpDelete("{idConsulta}")]
        public IActionResult Deletar(int idConsulta)
        {
            try
            {
                Consultum teste = _consultaRepository.BuscarPorID(idConsulta);
                if (teste != null)
                {
                    _consultaRepository.Deletar(idConsulta);

                    return StatusCode(204);
                }

                return NotFound("A consulta não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [HttpPost("situacao/{idConsulta}")]
        public IActionResult AlterarSituacao(int idConsulta, Consultum consulta)
        {
            try
            {
                Consultum teste = _consultaRepository.BuscarPorID(idConsulta);
                if (teste == null) { return NotFound("A consulta não foi encontrada :P"); }
                if (consulta.Situacao != "Agendada" && consulta.Situacao != "Realizada" && consulta.Situacao != "Cancelada")
                {
                    return BadRequest("Retorne 'Agendada', 'Realizada' ou 'Cancelada'");
                }
                _consultaRepository.AlterarSituação(idConsulta, consulta);
                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
      
        }
    }
}
