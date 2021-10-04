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

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            List<Clinica> listaClinica = _clinicaRepository.Listar();

            return Ok(listaClinica);
        }

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

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Clinica clinica)
        {
            _clinicaRepository.Cadastrar(clinica);

            return StatusCode(201);
        }

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
