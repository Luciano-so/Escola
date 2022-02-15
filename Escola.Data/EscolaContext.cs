

using Escola.Core.Data;
using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Data
{
    public class EscolaContext : DbContext, IUnitOfWork
    {
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<AlunoNota> AlunoNota { get; set; }
        public DbSet<AlunoCurso> AlunoCurso { get; set; }
        public EscolaContext(DbContextOptions<EscolaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EscolaContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            var entitiesAdded = new List<EntityEntry>();
            var entitiesModified = new List<EntityEntry>();
            var entitiesDeleted = new List<EntityEntry>();

            foreach (var entry in this.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added: entitiesAdded.Add(entry); break;
                    case EntityState.Modified: entitiesModified.Add(entry); break;
                    case EntityState.Deleted: entitiesDeleted.Add(entry); break;
                }
            }
            return await base.SaveChangesAsync() > 0;
        }
    }
}
