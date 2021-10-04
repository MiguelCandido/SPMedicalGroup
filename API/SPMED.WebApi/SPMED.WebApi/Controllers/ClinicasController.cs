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
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            List<Clinica> listaClinica = _clinicaRepository.Listar();

            return Ok(listaClinica);
        }

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

        [HttpPost]
        public IActionResult Cadastrar(Clinica clinica)
        {
            _clinicaRepository.Cadastrar(clinica);

            return StatusCode(201);
        }

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
