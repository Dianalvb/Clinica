using Clinica.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Clinica.API.Data
{
    public class SeederDB
    {
        private readonly DataContext dataContext;
        public SeederDB(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        
        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();
            await CheckAgendasAsync();
            await CheckPatientsAsync();
            await CheckConsultsAsync();
            await CheckDiagnosesAsync();
            await CheckTreatmentsAsync();
            await CheckMedicationsAsync();
        }
        private async Task CheckAgendasAsync()
        {
            if (!dataContext.Agendas.Any())
            {
                var patient = await dataContext.Patients.FirstOrDefaultAsync(x => x.Name == "Hugo");
                if (patient != null)
                {
                    dataContext.Agendas.Add(new Agenda { Name = "Hugo", Patient = patient });
                    await dataContext.SaveChangesAsync();
                }   
            }
        }
        private async Task CheckConsultsAsync()
        {
            if (!dataContext.Consults.Any())
            {
                var diagnosis = await dataContext.Diagnoses.FirstOrDefaultAsync(x => x.Name == "Hugo");
                if (diagnosis != null)
                {
                    dataContext.Consults.Add(new Consult { Name = "Hugo", Diagnosis = diagnosis });
                    }
                await dataContext.SaveChangesAsync();
            }
        }
        
        private async Task CheckTreatmentsAsync()
        {
            if (!dataContext.Treatments.Any())
            {
                var medication = await dataContext.Medications.FirstOrDefaultAsync(x => x.Name == "dietilcarbamazina (DEC)");
                if (medication != null)
                {
                    dataContext.Treatments.Add(new Treatment { Description = "El tratamiento consiste en antibióticos y antiparasitarios\r\nTomar fármacos una vez al año puede matar los parásitos.", Medication = medication });
                    await dataContext.SaveChangesAsync();
                }
            }
        }
        private async Task CheckDiagnosesAsync()
        {
            if (!dataContext.Diagnoses.Any())
            {
                
                    dataContext.Diagnoses.Add(new Diagnosis { Name = "Elefantitis" });
                    await dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckMedicationsAsync()
        {
            if (!dataContext.Medications.Any())
            {
                dataContext.Medications.Add(new Medication { Name = "dietilcarbamazina(DEC)", Description="Medicamento", Strength=500 });

                await dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckPatientsAsync()
        {
            if (!dataContext.Patients.Any())
            {
                    dataContext.Patients.Add(new Patient { Name = "Hugo", LastName="Díaz", SurName="Sanchez", Colonia="Conocida", Phone="222222222", Street="Conocida1", Email="Hugo@gmail.com", InsuranceNumber=5623 });
                    await dataContext.SaveChangesAsync();
                
            }
        }
    }
}