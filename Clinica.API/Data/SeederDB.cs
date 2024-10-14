using Clinica.Shared.Entities;
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
            await CheckConsultsAsync();
            await CheckDiagnosesAsync();
            await CheckMedicationsAsync();
            await CheckPatientsAsync();
            await CheckTreatmentsAsync();
        }
        private async Task CheckAgendasAsync()
        {
            if (!dataContext.Agendas.Any())
            {
            dataContext.Agendas.Add(new Agenda { Name = "Julian Perez", ConsultDate = "11 Noviembre 2024", Symptoms = "Dolor de cabeza, mareos, nauseas", ConsultHour = 8 });
                
                await dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckConsultsAsync()
        {
            if (!dataContext.Consults.Any())
            {
                dataContext.Consults.Add(new Consult { Name = "Julian Perez", Symptoms = "olor de cabeza, dolor de garganta, dolor corporal, fatiga", ConsultDate = "11 Noviembre 2024", Diagnosis = "Influenza", DoctorsName = "Javier Figueroa" });
                await dataContext.SaveChangesAsync();
            }
            
        }

        private async Task CheckTreatmentsAsync()
        {
            if (!dataContext.Treatments.Any())
            {
                dataContext.Treatments.Add(new Treatment { Description = "Tomar ibuprofeno cada 8 horas", Diagnosis = "Influenza", DoctorName ="Javier Figueroa", PatientName = "Julian Perez" });
                await dataContext.SaveChangesAsync();
            }

            
        }
        private async Task CheckDiagnosesAsync()
        {
            if (!dataContext.Diagnoses.Any())
            {
                dataContext.Diagnoses.Add(new Diagnosis { Description = "enfermedad respiratoria contagiosa causada por virus", DoctorName = "Javier Figueroa", Name = "", PatientName = "Julian Perez", Symptoms = "dolor de cabeza, dolor de garganta, dolor corporal, fatiga" });
                await dataContext.SaveChangesAsync();
            }
            
        }
        private async Task CheckMedicationsAsync()
        {
            if (!dataContext.Medications.Any())
            {
                dataContext.Medications.Add(new Medication { Name = "Ibuprofeno", Description = "Tomar ibuprofeno cada 8 horas", Strength = 500 });
                await dataContext.SaveChangesAsync();
            }
            
        }
        private async Task CheckPatientsAsync()
        {
            if (!dataContext.Patients.Any())
            {
                dataContext.Patients.Add(new Patient { Name = "Julian", Active = true, Colonia = "", Email = "Julian.p@gmail.com", InsuranceNumber = 444, LastName = "Perez", Phone = "222 123 456 5", Street = "", SurName = "Garcia" });
                await dataContext.SaveChangesAsync();
            }
            
        }
    }
}
