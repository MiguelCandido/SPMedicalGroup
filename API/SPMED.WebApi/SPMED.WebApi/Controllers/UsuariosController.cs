using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPMED.WebApi.Domains;
using SPMED.WebApi.Interfaces;
using SPMED.WebApi.Repositories;
using SPMED.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMED.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista os usuarios
        /// </summary>
        /// <returns> Uma lista de usuarios</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            List<Usuario> listaUsuario = _usuarioRepository.Listar();

            return Ok(listaUsuario);
        }

        /// <summary>
        /// Busca um usuario pelo id
        /// </summary>
        /// <param name="idUsuario">id do usuario a ser buscado</param>
        /// <returns>um usuario encontrado</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{idUsuario}")]
        public IActionResult BuscarPorID(int idUsuario)
        {
            try
            {
                Usuario teste = _usuarioRepository.BuscarPorID(idUsuario);
                if (teste != null)
                {
                    return Ok(teste);
                }
                return NotFound("O usuario não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        
        }

        /// <summary>
        /// Cadastra um usuario
        /// </summary>
        /// <param name="usuario">Objeto com os dados do usuario</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um usuario
        /// </summary>
        /// <param name="idUsuario">id do usuario a ser atualizado</param>
        /// <param name="usuarioUPDT">dados novos do usuario</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idUsuario}")]
        public IActionResult Atualizar(int idUsuario, Usuario usuarioUPDT)
        {
            try
            {
                Usuario teste = _usuarioRepository.BuscarPorID(idUsuario);
                if (teste != null)
                {
                    _usuarioRepository.Atualizar(idUsuario, usuarioUPDT);

                    return StatusCode(204);
                }

                return NotFound("O usuario não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// deleta um usuario
        /// </summary>
        /// <param name="idUsuario">id do usuario a ser deletado</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idUsuario}")]
        public IActionResult Deletar(int idUsuario)
        {
            try
            {
                Usuario teste = _usuarioRepository.BuscarPorID(idUsuario);
                if (teste != null)
                {
                    _usuarioRepository.Deletar(idUsuario);

                    return StatusCode(204);
                }

                return NotFound("O usuario não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

  
        }
    }
}
