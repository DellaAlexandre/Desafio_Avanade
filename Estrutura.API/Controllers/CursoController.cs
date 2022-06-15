using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfessorCurso.ViewModel;
using ProfessorCurso.Services;
using ProfessorCurso.Models;
using System.Collections.Generic;
using System;

namespace Estrutura.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        private CursoServices _cursoServices = new CursoServices();

        [HttpPost]
        public IActionResult CadastrarCurso([FromBody] CursoViewModel cursoRecebido)
        {
            if (cursoRecebido.NomeMateria == null)
                return BadRequest("Não foi recebido nenhum Nome do Curso.");
            
            Curso cursoCriado = _cursoServices.CadastrarCurso(cursoRecebido);
            return Created("Curso", cursoCriado);
        }

        [HttpGet]
        public IActionResult ObterCurso()
        {
            List<Curso> listar = _cursoServices.ListarCursos();
            return Ok(listar);
        }

        [HttpDelete("{id}")]
        public IActionResult deletarCurso(Guid id)
        {
            if (!_cursoServices.ExisteCurso(id))
                return BadRequest("Não encontrado o Id: " + id);

            _cursoServices.DeletarCurso(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult AtualizarCurso([FromBody] CursoViewModel cursoRecebido, Guid id)
        {
            if(!_cursoServices.ExisteCurso(id) || cursoRecebido == null)
                return NotFound("Não encontrado, por favor tente novamente");
            
            _cursoServices.AtualizarCurso(cursoRecebido,id);
            return NoContent();
        }

    }
}
