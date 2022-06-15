using ProfessorCurso.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProfessorCurso.Models
{
    public class Curso
    {
        public Curso()
        {

        }

        public Curso(CursoViewModel cursoRecebido)
        {
            Id = new Guid();
            NomeMateria = cursoRecebido.NomeMateria;
            DescricaoMateria = cursoRecebido.DescricaoMateria;
            IdProfessor = cursoRecebido.IdProfessor;

        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string NomeMateria { get; set; }
        public string DescricaoMateria { get; set; }
        [Required]
        public string IdProfessor { get; set; }
    }
}
