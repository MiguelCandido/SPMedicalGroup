﻿using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Medico medico)
        {
            _medicoRepository.Cadastrar(medico);

            return StatusCode(201);
        }

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

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_medicoRepository.Listar());
        }
    }
}
