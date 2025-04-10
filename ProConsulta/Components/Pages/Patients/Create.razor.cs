using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories;

namespace ProConsulta.Components.Pages.Patients
{
    public class CreatePatientPage : ComponentBase
    {

        [Inject]
        public IPatientRepository repository { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        public PatientInputModel InputModel { get; set; } = new PatientInputModel();

        public DateTime? DateBirth { get; set; } = DateTime.Today;
        
        public DateTime? MaxDate { get; set; } = DateTime.Today;

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if(editContext.Model is PatientInputModel model)
                {
                    var patient = new Patient
                    {
                        Name = model.Name,
                        Documents = model.Document.CharactersOnly(),
                        Phone = model.Phone.CharactersOnly(),
                        Email = model.Email,
                        DateBirth = DateBirth.Value
                    };

                    await repository.AddAsync(patient);
                    Snackbar.Add("Paciente cadastrado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/patients");
                }
            }
            catch(Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
    


    }
}
