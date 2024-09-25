using Clinica.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinica.API.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Consult> Consults { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base (options) 
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Agenda>().HasIndex(x => new { x.Name, x.Date }).IsUnique();
            modelBuilder.Entity<Consult>().HasIndex(x => x.Name).IsUnique();
        }
    }
}
