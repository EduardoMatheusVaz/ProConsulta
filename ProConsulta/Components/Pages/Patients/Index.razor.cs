using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories;

namespace ProConsulta.Components.Pages.Patients
{
    public class IndexPage : ComponentBase 
    {

        [Inject]
        public IPatientRepository repository { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public List<Patient> Patients { get; set; } = new();

        public bool HideButtons { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        public async Task DelegatePatient(Patient patient)
        {
            try
            {
                var result = await Dialog.ShowMessageBox
                 (
                    "Atenção",
                    $"Deseja realizar a exclusão do paciente {patient.Name}",
                    yesText: "SIM",
                    cancelText: "NÃO"
                 );

                if(result is true)
                {
                    await repository.DeleteByIdAsync(patient.Id);
                    Snackbar.Add($"O paciente {patient.Name} foi excluído com sucesso!", Severity.Success); // O Severity indica de uma forma gráfica a ação que foi executada
                    await OnInitializedAsync(); // Precisamos chamar novamente para que, a nossa tela atualize
                }
            }
            catch(Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public void GoToUpdate(int id)
        {
            NavigationManager.NavigateTo($"/patients/update/{id}");
        }

        protected override async Task OnInitializedAsync()
        {
            var auth = await AuthenticationState;

            HideButtons = !auth.User.IsInRole("Atendente"); /*se !auth.User.IsInROle for diferente de "Atendente", o HideButton passa a ser true e assim nós escondemos os botões*/

            Patients = await repository.GetAllAsync();
        }


    }
}
