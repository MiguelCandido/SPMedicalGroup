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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            List<Usuario> listaUsuario = _usuarioRepository.Listar();

            return Ok(listaUsuario);
        }

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

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);

            return StatusCode(201);
        }

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
