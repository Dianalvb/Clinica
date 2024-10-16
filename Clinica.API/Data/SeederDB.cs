using Clinica.Shared.Entities;
using Microsoft.EntityFrameworkCore;

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
        private async Task CheckPatientsAsync()
        {
            if (!dataContext.Patients.Any())
            {
                dataContext.Patients.Add(new Patient { Name = "Hugo", LastName = "Díaz", SurName = "Sanchez", Colonia = "Conocida", Phone = "222222222", Street = "Conocida1", Email = "hugo@gmail.com", InsuranceNumber = 5623 });

                dataContext.Patients.Add(new Patient { Name = "Ana", LastName = "Perez", SurName = "Lopez", Colonia = "Desconocida", Phone = "333333333", Street = "Desconocida1", Email = "ana@gmail.com", InsuranceNumber = 1234 });
                await dataContext.SaveChangesAsync();

            }
        }

        private async Task CheckConsultsAsync()
        {
            if (!dataContext.Consults.Any())
            {

                var diagnosticHugo = await dataContext.Diagnoses.FirstOrDefaultAsync(x => x.Name == "Gastritis Aguda");
                var diagnostocAna = await dataContext.Diagnoses.FirstOrDefaultAsync(x => x.Name == "Migraña Crónica");
                if (diagnosticHugo != null && diagnostocAna != null)
                {
                    dataContext.Consults.Add(new Consult { Name = "Hugo", DoctorsName = "Dr. Juan", ConsultDate = new DateTime(2024, 10, 19), Symptoms = "Dolor de cabeza", Diagnosis = diagnosticHugo });
                    dataContext.Consults.Add(new Consult { Name = "Ana", DoctorsName = "Dra. Maria", ConsultDate = new DateTime(2024, 11, 5), Symptoms = "Fiebre", Diagnosis = diagnostocAna });

                    await dataContext.SaveChangesAsync();
                }
            }
        }

        private async Task CheckAgendasAsync()
        {
            if (!dataContext.Agendas.Any())
            {

                var hugo = await dataContext.Patients.FirstOrDefaultAsync(p => p.Name == "Hugo");
                var ana = await dataContext.Patients.FirstOrDefaultAsync(p => p.Name == "Ana");

                if (hugo != null && ana != null)
                {
                    dataContext.Agendas.Add(new Agenda { Name = "Hugo", ConsultDate=new DateTime(2024, 10, 19), ConsultHour=6, Symptoms= "Dolor de cabeza", Patient = hugo });
                    dataContext.Agendas.Add(new Agenda { Name = "Ana", ConsultDate= new DateTime(2024, 11, 5), ConsultHour=3, Symptoms= "Fiebre", Patient = ana });


                    await dataContext.SaveChangesAsync();
                }

            }
        }
        private async Task CheckDiagnosesAsync()
        {
            if (!dataContext.Diagnoses.Any())
            {
                var TreatmentHugo = await dataContext.Treatments.FirstOrDefaultAsync(p => p.Description == "El tratamiento de la gastritis aguda se enfoca en eliminar la causa de la inflamación, reducir los síntomas y prevenir el daño adicional al estómago.");
                var TreatmentAna = await dataContext.Treatments.FirstOrDefaultAsync(p => p.Description == "El tratamiento de la migraña crónica suele enfocarse en reducir la frecuencia, duración e intensidad de los episodios.");

                if (TreatmentHugo != null && TreatmentAna != null)
                {
                    dataContext.Diagnoses.Add(new Diagnosis { Name = "Gastritis Aguda", Description= "La gastritis aguda es la inflamación del revestimiento del estómago, que puede ser causada por infecciones, uso excesivo de analgésicos o el consumo de alcohol. Los episodios de gastritis pueden causar dolor abdominal severo y molestias digestivas.", DoctorName= "Dr. Juan", PatientName="Hugo", Symptoms= "Dolor de cabeza", Treatment = TreatmentHugo });
                    dataContext.Diagnoses.Add(new Diagnosis { Name = "Migraña Crónica", Description = "La migraña crónica es un trastorno neurológico que causa dolores de cabeza intensos, que pueden durar horas o incluso días. A menudo, se acompañan de otros síntomas como náuseas, vómitos y sensibilidad extrema a la luz y al sonido. Esta condición puede afectar significativamente la calidad de vida.", DoctorName = "Dra. Maria", PatientName = "Ana", Symptoms = "Fiebre", Treatment = TreatmentAna });

                    await dataContext.SaveChangesAsync();
                }
            }
        }
        private async Task CheckTreatmentsAsync()
        {
            if (!dataContext.Treatments.Any())
            {

                var MedHugo = await dataContext.Medications.FirstOrDefaultAsync(p => p.Name == "omeprazol");
                var MedAna = await dataContext.Medications.FirstOrDefaultAsync(p => p.Name == "Sumatriptán");

                if (MedHugo != null && MedAna != null)
                {
                    dataContext.Treatments.Add(new Treatment { Description = " El tratamiento de la gastritis aguda se enfoca en eliminar la causa de la inflamación, reducir los síntomas y prevenir el daño adicional al estómago.", PatientName="Hugo", DoctorName= "Dr. Juan", Diagnosis= "Gastritis Aguda", Medication = MedHugo });
                    dataContext.Treatments.Add(new Treatment { Description = "El tratamiento de la migraña crónica suele enfocarse en reducir la frecuencia, duración e intensidad de los episodios.", PatientName = "Ana", DoctorName = "Dra. Maria", Diagnosis = "Migraña Crónica", Medication = MedAna });
                    await dataContext.SaveChangesAsync();
                }
            }
        }

        private async Task CheckMedicationsAsync()
        {
            if (!dataContext.Medications.Any())
            {
                dataContext.Medications.Add(new Medication { Name = "omeprazol", Description = "Tomar cada que sienta molestia", Strength = 500 });
                dataContext.Medications.Add(new Medication { Name = "Sumatriptán", Description = "Tomar cada que sienta molestia", Strength = 500 });
                await dataContext.SaveChangesAsync();
            }
        }
    }
}