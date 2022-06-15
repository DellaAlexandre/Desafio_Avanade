using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estrutura.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Estrutura : ControllerBase
    {
        [HttpGet]
        public string inicio()
        {
            return "Bem vindo a API de Cadastro de Professores e Cursos, Regra: Não é possivel cadastrar um professor em mais de um Curso";
        }
        

    }
}
