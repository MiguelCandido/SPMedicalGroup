using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
        /// <summary>
        /// cadastra um paciente
        /// </summary>
        /// <param name="paciente">objeto com os dados do novo paciente</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Paciente paciente)
        {
            _pacienteRepository.Cadastrar(paciente);

            return StatusCode(201);
        }

        /// <summary>
        /// atualiza um paciente
        /// </summary>
        /// <param name="idPaciente">id do paciente a ser atualizado</param>
        /// <param name="pacienteUPDT">objeto com os dados do paciente a serem atualizados</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
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

        /// <summary>
        /// deleta um paciente
        /// </summary>
        /// <param name="idPaciente">id do paciente a ser deletado</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
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
        /// <summary>
        /// Lista os pacientes
        /// </summary>
        /// <returns> Uma lista de pacientes</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_pacienteRepository.Listar());
        }
    }
}
