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

        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string NomeMateria { get; set; }
        public string DescricaoMateria { get; set; }
        [Required]
        public Professor IdProfessor { get; set; }
    }
}
