
using Examen2Progra.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace Examen2Progra.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Meta> Metas { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.Meta)
                .WithMany(m => m.Tareas)
                .HasForeignKey(t => t.MetaId);

            base.OnModelCreating(modelBuilder);
        }
    }
}