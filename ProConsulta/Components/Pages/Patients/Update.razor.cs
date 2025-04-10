using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories;

namespace ProConsulta.Components.Pages.Patients
{
    public class UpdatePatientPage : ComponentBase
    {
        [Parameter] // Adicionei isso para essa propriedade se comportar como um parametro para receber ele fora do componente
        public int PatientId{ get; set; }

        [Inject]
        public IPatientRepository repository { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public PatientInputModel InputModel = new PatientInputModel();
        private Patient? CurrentPatient { get; set; }
        public DateTime? DateBirth { get; set; } = DateTime.Today;
        public DateTime? MaxDate { get; set; } = DateTime.Today;


        protected override async Task OnInitializedAsync()
        {
            CurrentPatient = await repository.GetByIdAsync(PatientId);
            if (CurrentPatient is null)
                return;

            InputModel = new PatientInputModel
            {
                Id = CurrentPatient.Id,
                Name = CurrentPatient.Name,
                Document = CurrentPatient.Documents,
                Phone = CurrentPatient.Phone,
                DateBirth = CurrentPatient.DateBirth,
                Email = CurrentPatient.Email
            };

            DateBirth = CurrentPatient.DateBirth;
        }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if(editContext.Model is PatientInputModel model) // Se nosso EditContext.Model for nosso pacienteInputModel eu nomeio ele de model
                {
                    CurrentPatient.Name = model.Name;
                    CurrentPatient.Documents = model.Document.CharactersOnly();
                    CurrentPatient.Phone = model.Phone.CharactersOnly();
                    CurrentPatient.Email = model.Email;
                    CurrentPatient.DateBirth = DateBirth.Value;

                    await repository.UpdateAsync(CurrentPatient);
                    Snackbar.Add($"Paciente {CurrentPatient.Name} atualizado com sucesos!", Severity.Success);
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
