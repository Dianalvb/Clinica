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
            /*await CheckConsultsAsync();
            await CheckDiagnosesAsync();
            await CheckMedicationsAsync();
            await CheckPatientsAsync();
            await CheckTreatmentsAsync();*/
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
                var treatment = await dataContext.Treatments.FirstOrDefaultAsync(x => x.Description == "\"El tratamiento consiste en antibióticos y antiparasitarios\\r\\nTomar fármacos una vez al año puede matar los parásitos.");
                if (treatment != null)
                {
                    dataContext.Diagnoses.Add(new Diagnosis { Name = "Elefantitis" });
                    await dataContext.SaveChangesAsync();
                }
            }
        }
        private async Task CheckMedicationsAsync()
        {
            if (!dataContext.Medications.Any())
            {
                dataContext.Medications.Add(new Medication { Name = "dietilcarbamazina(DEC)" });

                await dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckPatientsAsync()
        {
            if (!dataContext.Patients.Any())
            {
                var consult = await dataContext.Consults.FirstOrDefaultAsync(x => x.Name == "Hugo");
                if (consult != null)
                {
                    dataContext.Patients.Add(new Patient { Name = "Hugo", Consult = consult });
                    await dataContext.SaveChangesAsync();
                }
                
            }
        }
    }
}