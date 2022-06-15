using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfessorCurso.Models;
using ProfessorCurso.Services;
using ProfessorCurso.ViewModel;
using System;
using System.Collections.Generic;

namespace Estrutura.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        private ProfessoreServices _professorServices = new ProfessoreServices();

        [HttpPost]
        public IActionResult CadastrarProfessor([FromBody] ProfessorViewModel professorRecebido)
        {
            if(professorRecebido.Nome == null)
                return BadRequest("Não foi recebido nenhum Nome de Professor.");
            
            Professor professorCriado = _professorServices.CadastrarProfessor(professorRecebido);
            return Created("Professor", professorCriado);
        }

        [HttpGet]
        public IActionResult ObterProfessores()
        {
            List<Professor> lista = _professorServices.ListarProfessores();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult ObterProfessor(string id)
        {
            Professor professor = _professorServices.ObterProfessor(id);
            if (professor == null)
            {
                return NotFound("Não existe esse Professor Cadastrado");
            }

            return Ok(professor);
        }

        [HttpDelete ("{id}")]
        public IActionResult DeletarProfessor(Guid id)
        {
            if (!_professorServices.ExisteProfessor(id))
                return NotFound("Não encontrado o id: " + id);
            
            _professorServices.DeletarProfessor(id);
            return NoContent();
        }

        [HttpPut ("{id}")]
        public IActionResult AtualizaProfessor([FromBody] ProfessorViewModel professorRecebido, Guid id)
        {
            if (!_professorServices.ExisteProfessor(id) || professorRecebido == null)
                return NotFound("Não encontrado, por favor tente novamente");

            _professorServices.AtualizaProfessor(professorRecebido, id);

            return NoContent();
        }
    }
}
