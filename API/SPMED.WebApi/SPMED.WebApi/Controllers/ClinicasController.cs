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
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }
        /// <summary>
        /// Lista as clinicas
        /// </summary>
        /// <returns> Uma lista de clinicas</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            List<Clinica> listaClinica = _clinicaRepository.Listar();

            return Ok(listaClinica);
        }

        /// <summary>
        /// Busca uma clinica por id
        /// </summary>
        /// <param name="idClinica">id da clinica a ser buscada</param>
        /// <returns>uma clinica encontrada</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{idClinica}")]
        public IActionResult BuscarPorID(int idClinica)
        {
            try
            {
                Clinica teste = _clinicaRepository.BuscarPorID(idClinica);
                if (teste != null)
                {
                    return Ok(teste);
                }
                return NotFound("A clinica não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        /// cadastra uma clinica
        /// </summary>
        /// <param name="clinica">objeto clinica com os dados a serem cadastrados</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Clinica clinica)
        {
            _clinicaRepository.Cadastrar(clinica);

            return StatusCode(201);
        }

        /// <summary>
        /// atualiza uma clinica
        /// </summary>
        /// <param name="idClinica">id da clinica a ser atualizada</param>
        /// <param name="clinicaUPDT">dados das clinicas a serem atualizados</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idClinica}")]
        public IActionResult Atualizar(int idClinica, Clinica clinicaUPDT)
        {
            try
            {
                Clinica teste = _clinicaRepository.BuscarPorID(idClinica);
                if (teste != null)
                {
                    _clinicaRepository.Atualizar(idClinica, clinicaUPDT);

                    return StatusCode(204);
                }

                return NotFound("A clinica não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// deleta uma clinica
        /// </summary>
        /// <param name="idClinica">id da clinica a ser deletada</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idClinica}")]
        public IActionResult Deletar(int idClinica)
        {
            try
            {
                Clinica teste = _clinicaRepository.BuscarPorID(idClinica);
                if (teste != null)
                {
                    _clinicaRepository.Deletar(idClinica);

                    return StatusCode(204);
                }

                return NotFound("A clinica não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }


        }

    }
}
