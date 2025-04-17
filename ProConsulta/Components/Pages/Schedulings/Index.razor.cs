using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Schedulings;
using System.Threading.Tasks;

namespace ProConsulta.Components.Pages.Schedulings
{
    public class IndexSchedulingPage : ComponentBase
    {

        [Inject]
        public ISchedulingsRepository repository { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

        public List<Scheduling> Schedulings = new List<Scheduling>();

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        public bool HidenButtons { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var auth = await AuthenticationState;

            HidenButtons = !auth.User.IsInRole("Atendente");

            Schedulings = await repository.GetAllAsync();
        }

        public void GoToUpdate(int id)
        {
            NavigationManager.NavigateTo($"/scheduling/update/{id}");
        }

        public async Task DeleteSchedulingAsync(Scheduling scheduling)
        {
            try
            {
                var result = await DialogService.ShowMessageBox
                    (
                        "Atenção",
                        $"Deseja mesmo excluir este agendamento marcado para o dia {scheduling.ConsultationDate} as {scheduling.ConsultationTime} horas?",
                        yesText:"SIM",
                        cancelText:"NÃO"
                    );
                    
                if(result is true)
                {
                    await repository.DeleteByIdAsync(scheduling.Id);
                    Snackbar.Add("Agendamento excluído com sucesso!", Severity.Success);
                    await OnInitializedAsync();
                }
            }
            catch(Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

    }
}
