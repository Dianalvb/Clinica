using Clinica.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinica.API.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Consult> Consults { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base (options) 
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Agenda>().HasIndex(x => x.Name).IsUnique();
        }
    }
}
