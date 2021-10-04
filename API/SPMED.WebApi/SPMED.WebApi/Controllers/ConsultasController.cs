using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPMED.WebApi.Domains;
using SPMED.WebApi.Interfaces;
using SPMED.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SPMED.WebApi.Controllers
{
    [Authorize]
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

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            List<Consultum> listaConsulta = _consultaRepository.Listar();

            return Ok(listaConsulta);
        }


        [Authorize(Roles = "1")]
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

        [Authorize(Roles = "1")]
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

        [Authorize(Roles = "1")]
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

        [Authorize(Roles = "1")]
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

        [Authorize(Roles = "1")]
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

        [Authorize(Roles = "2,3")]
        [HttpGet("minhas")]
        public IActionResult ListarMinhas()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(u => u.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.listarMinhas(idUsuario));
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as presenças se o usuário não estiver logado!"

                });
            }
        }

        [Authorize(Roles = "2")]
        [HttpPost("descrever/{idusuario}")]
        public IActionResult Descrever(int idusuario, Consultum consulta)
        {
            try
            {
                if(consulta.Descricao == null) {

                    return BadRequest(new
                    {
                        mensagem = "Informe a descrição"

                    });
                }

                _consultaRepository.Descrever(idusuario, consulta);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
