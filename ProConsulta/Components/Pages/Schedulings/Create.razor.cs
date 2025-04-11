using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories;
using ProConsulta.Repositories.Doctors;
using ProConsulta.Repositories.Schedulings;

namespace ProConsulta.Components.Pages.Schedulings
{
    public class CreateSchedulingPage : ComponentBase
    {

        [Inject]
        public ISchedulingsRepository schedulingsRepository { get; set; } = null!;

        [Inject]
        public IDoctorRepository doctorRepository { get; set; } = null!;

        [Inject]
        public IPatientRepository patientRepository { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        NavigationManager NavigationManager { get; set; } = null!;

        public SchedulingInputModel InputModel {get; set;} = new SchedulingInputModel();
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public List<Patient> Patients { get; set; } = new List<Patient>();

        public TimeSpan? time = new TimeSpan(09, 00, 00);
        public DateTime? date { get; set; } = DateTime.Now.Date;
        public DateTime? MinDate { get; set; } = DateTime.Now.Date;


        protected override async Task OnInitializedAsync()
        {
            Doctors = await doctorRepository.GetAllAsync();
            Patients = await patientRepository.GetAllAsync();
        }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if(editContext.Model is SchedulingInputModel model)
                {
                    var scheduling = new Scheduling
                    {
                        Observation = model.Observation,
                        PatientId = model.PacientId,
                        DoctorId = model.DoctorId,
                        ConsultationTime = time!.Value,
                        ConsultationDate = date!.Value
                    };

                    await schedulingsRepository.AddAsync(scheduling);
                    Snackbar.Add("Agendamento cadastrado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/schedulings");
                }
            }
            catch(Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }



    }
}
