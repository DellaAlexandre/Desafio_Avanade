using ProfessorCurso.Models;
using ProfessorCurso.Respository;
using ProfessorCurso.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProfessorCurso.Services
{
    public class CursoServices
    {
        private applicationDbContext _context = new applicationDbContext();        

        public bool ExisteCurso(Guid id)
        {
            return _context.Cursos.Any(c => c.Id == id);
        }

        public Curso ObterCurso( String idRecebido)
        {
            List<Curso> lista = ListarCursos();
            if (lista.Any(c => c.Id.ToString() == idRecebido))
            {
                Curso curso = lista.Where(c => c.Id.ToString() == idRecebido).First();
                return curso;
            }

            return null;

        } 
        public Curso CadastrarCurso(CursoViewModel cursoRecebido)
        {
            Curso curso = new Curso(cursoRecebido);
            _context.Cursos.Add(curso);
            _context.SaveChanges();
            return curso;
        }

        public Curso BuscaCurso(Guid id)
        {
            return _context.Cursos.Where(curso => curso.Id == id).FirstOrDefault();
        }

        public List<Curso> ListarCursos()
        {
            return _context.Cursos.OrderBy(curso => curso.NomeMateria).ToList();
        }

        public bool VerificaProfessor(string idProfessor)
        {
            return _context.Cursos.Any(c => c.IdProfessor == idProfessor);
        }

        public void DeletarCurso(Guid id)
        {
            Curso curso = BuscaCurso(id);
            _context.Remove(curso);
            _context.SaveChanges();
        }

        public void AtualizarCurso(CursoViewModel cursoRecebido, Guid id)
        {
            Curso curso = BuscaCurso(id);
            if (cursoRecebido.NomeMateria != null)
            {
                curso.NomeMateria = cursoRecebido.NomeMateria;
            }
            if (cursoRecebido.DescricaoMateria != null)
            {
                curso.DescricaoMateria = cursoRecebido.DescricaoMateria;
            }
            
            if (cursoRecebido.IdProfessor != null && VerificaProfessor(cursoRecebido.IdProfessor))
            {
                curso.IdProfessor = cursoRecebido.IdProfessor;
            }
            
            _context.SaveChanges();
            
        }

    }
}
