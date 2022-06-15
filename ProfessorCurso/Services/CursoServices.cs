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
            return _context.Cursos.Any(p => p.Id == id);
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

        public void DeletarCurso(Guid id)
        {
            Curso curso = BuscaCurso(id);
            _context.Remove(curso);
            _context.SaveChanges();
        }

        public void AtualizarCurso(CursoViewModel cursoRecebido, Guid id)
        {
            Curso curso = BuscaCurso(id);
            curso.NomeMateria = cursoRecebido.NomeMateria;
            curso.DescricaoMateria = cursoRecebido.DescricaoMateria;
            curso.IdProfessor = cursoRecebido.IdProfessor;
            _context.SaveChanges();
        }

    }
}
