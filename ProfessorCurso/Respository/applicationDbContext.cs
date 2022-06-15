using Microsoft.EntityFrameworkCore;
using ProfessorCurso.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessorCurso.Respository
{
    public class applicationDbContext : DbContext
    {
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Curso> Cursos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder construtor)
        {
            string conexao = "Server=localhost\\SQLEXPRESS;" + "Database=PC;Integrated Security=SSPI"; construtor.UseSqlServer(conexao);
        }

    }
}
