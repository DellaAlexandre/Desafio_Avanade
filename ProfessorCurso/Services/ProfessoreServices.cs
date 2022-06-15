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

        public Professor ObterProfessor(String idRecebido)
        {
            List<Professor> lista = ListarProfessores();
            if (lista.Any(c => c.Id.ToString() == idRecebido))
            {
                Professor professor = lista.Where(c => c.Id.ToString() == idRecebido).First();
                return professor;
            }

            return null;

        }

        public Professor BuscaProfessor(Guid id)
        {
            return _context.Professores.Where(professor => professor.Id == id).FirstOrDefault();
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
            Professor professor = BuscaProfessor(id);
            _context.Remove(professor);
            _context.SaveChanges();
        }

        public void AtualizaProfessor(ProfessorViewModel professorRecebido, Guid id)
        {
            Professor professor = BuscaProfessor(id);

            if( professorRecebido.Nome != null)
            {
                professor.Nome = professorRecebido.Nome;
            }
            
            if(professorRecebido.Email != null) 
            { 
                professor.Email = professorRecebido.Email; 
            }

            if(professorRecebido.Idade != 0)
            {
                professor.Idade = professorRecebido.Idade;
            }
           
            if(professorRecebido.Status != null)
            {
                professor.Status = professorRecebido.Status;
            }
            
            _context.SaveChanges();
        }


    }
}
