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
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }

        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// cadastra um medico
        /// </summary>
        /// <param name="medico">objeto com os dados do novo medico</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Medico medico)
        {
            _medicoRepository.Cadastrar(medico);

            return StatusCode(201);
        }
        /// <summary>
        /// atualiza os dados de um medico
        /// </summary>
        /// <param name="idMedico">id do medico a ser atualizado</param>
        /// <param name="medicoUPDT">objeto com os dados do medico a serem atualizados</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idMedico}")]
        public IActionResult Atualizar(int idMedico, Medico medicoUPDT)
        {
            try
            {
                Medico teste = _medicoRepository.BuscarPorID(idMedico);
                if (teste != null)
                {
                    _medicoRepository.Atualizar(idMedico, medicoUPDT);

                    return StatusCode(204);
                }

                return NotFound("O medico não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// deleta um medico do bd
        /// </summary>
        /// <param name="idMedico">id do medico a ser deletado</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idMedico}")]
        public IActionResult Deletar(int idMedico)
        {
            try
            {
                Medico teste = _medicoRepository.BuscarPorID(idMedico);
                if (teste != null)
                {
                    _medicoRepository.Deletar(idMedico);

                    return StatusCode(204);
                }

                return NotFound("O medico não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }


        }

        /// <summary>
        /// Lista os medicos
        /// </summary>
        /// <returns> Uma lista de medicos</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_medicoRepository.Listar());
        }
    }
}
