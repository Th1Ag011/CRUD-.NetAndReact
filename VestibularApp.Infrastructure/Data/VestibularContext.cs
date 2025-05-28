using Microsoft.EntityFrameworkCore;
using VestibularApp.Domain.Entities;

namespace VestibularApp.Infrastructure.Data
{
    public class VestibularContext : DbContext
    {
        public VestibularContext(DbContextOptions<VestibularContext> options)
            : base(options)
        {

        }

        public DbSet<Candidato>Candidatos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<ProcessoSeletivo> ProcessosSeletivos { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
    }
}
