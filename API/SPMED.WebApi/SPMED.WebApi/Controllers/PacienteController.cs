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
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(Paciente paciente)
        {
            _pacienteRepository.Cadastrar(paciente);

            return StatusCode(201);
        }
        [HttpPut("{idPaciente}")]
        public IActionResult Atualizar(int idPaciente, Paciente pacienteUPDT)
        {
            try
            {
                Paciente teste = _pacienteRepository.BuscarPorID(idPaciente);
                if (teste != null)
                {
                    _pacienteRepository.Atualizar(idPaciente, pacienteUPDT);

                    return StatusCode(204);
                }

                return NotFound("O paciente não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpDelete("{idPaciente}")]
        public IActionResult Deletar(int idPaciente)
        {
            try
            {
                Paciente teste = _pacienteRepository.BuscarPorID(idPaciente);
                if (teste != null)
                {
                    _pacienteRepository.Deletar(idPaciente);

                    return StatusCode(204);
                }

                return NotFound("O paciente não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }


        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_pacienteRepository.Listar());
        }
    }
}
