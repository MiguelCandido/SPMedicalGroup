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

        /// <summary>
        /// Lista as consultas
        /// </summary>
        /// <returns> uma lista de consultas</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            List<Consultum> listaConsulta = _consultaRepository.Listar();

            return Ok(listaConsulta);
        }

        /// <summary>
        /// Busca uma consulta por ID
        /// </summary>
        /// <param name="idConsulta">O id da consulta a ser buscada</param>
        /// <returns>A consulta encontrada</returns>
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

        /// <summary>
        /// Cadastra uma consulta
        /// </summary>
        /// <param name="consulta">O objeto com os dados da nova consulta</param>
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

        /// <summary>
        /// Atualiza uma consulta existente
        /// </summary>
        /// <param name="idConsulta">id da consulta a ser atualizada</param>
        /// <param name="consultaUPDT">Objeto com os dados novos da consulta</param>
        /// <returns></returns>
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

        /// <summary>
        /// Deleta uma consulta
        /// </summary>
        /// <param name="idConsulta">ID da consulta a ser deletada</param>
        /// <returns></returns>
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

        /// <summary>
        /// Altera a situação de uma consulta
        /// </summary>
        /// <param name="idConsulta"> id da consulta a ser alterada</param>
        /// <param name="consulta">objeto com a situação nova</param>
        /// <returns></returns>
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

        /// <summary>
        /// lista as consultas do usuário logado
        /// </summary>
        /// <returns>uma lista de consultas</returns>
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

        /// <summary>
        /// Adiciona a descrição da consulta
        /// </summary>
        /// <param name="idConsulta">id da consulta a ser descrita</param>
        /// <param name="consulta">objeto com a descrição da consulta</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPost("descrever/{idConsulta}")]
        public IActionResult Descrever(int idConsulta, Consultum consulta)
        {
            try
            {
                if(consulta.Descricao == null) {

                    return BadRequest(new
                    {
                        mensagem = "Informe a descrição"

                    });
                }

                _consultaRepository.Descrever(idConsulta, consulta);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
