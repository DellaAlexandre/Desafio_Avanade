using ProfessorCurso.Models;
using ProfessorCurso.Respository;
using ProfessorCurso.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProfessorCurso.Services
{
    public class ProfessoreServices
    {

        private applicationDbContext _context = new applicationDbContext();

        public bool ExisteProfessor(Guid id)
        {
          return _context.Professores.Any(p => p.Id == id);
        }

        public Professor CadastrarProfessor(ProfessorViewModel professorRecebido)
        {
            Professor professor = new Professor(professorRecebido);
            _context.Professores.Add(professor);
            _context.SaveChanges();
            return professor;
        }

        public List<Professor> ListarProfessores()
        {
            return _context.Professores.OrderBy(professor => professor.Nome).ToList();
        }

        public void DeletarProfessor( Guid id)
        {
            Professor professor = _context.Professores.Where(professor => professor.Id == id).FirstOrDefault();
            _context.Remove(professor);
            _context.SaveChanges();
        }

        public void AtualizaProfessor(ProfessorViewModel professorRecebido, Guid id)
        {
            Professor professor = _context.Professores.Where(professor => professor.Id == id).FirstOrDefault();

            professor.Nome = professorRecebido.Nome;
            professor.Email = professorRecebido.Email;
            professor.Idade = professorRecebido.Idade;
            professor.Status = professorRecebido.Status;
            _context.SaveChanges();
        }


    }
}
