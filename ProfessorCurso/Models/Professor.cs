using ProfessorCurso.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProfessorCurso.Models
{
    public class Professor
    {

        public Professor()
        {

        }


        public Professor( ProfessorViewModel professorRecebido)
        {
          Id = new Guid();
          Nome = professorRecebido.Nome;
          Idade = professorRecebido.Idade;
          Email = professorRecebido.Email;
          Status = "Ativo";

        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}
