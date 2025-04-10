using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Doctors;

namespace ProConsulta.Components.Pages.Doctors
{
    public class IndexPage : ComponentBase
    {

        [Inject]
        public IDoctorRepository repository { get; set; } = null!;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public List<Doctor> Doctors = new List<Doctor>();

        protected override async Task OnInitializedAsync()
        {
            Doctors = await repository.GetAllAsync();
        }

        public void GoToUpdate(int id)
        {
            NavigationManager.NavigateTo($"/doctors/update/{id}");
        }

        public async Task DeleteDoctorAsync(Doctor doctor)
        {
            try
            {
                var result = await DialogService.ShowMessageBox
                (
                    "Atenção",
                    $"Deseja mesmo excluir o Médico {doctor.Name}",
                    yesText:"SIM",
                    cancelText:"NÃO"
                );

                if(result is true)
                {
                    await repository.DeleteByIdAsync(doctor.Id);
                    Snackbar.Add($"Médico {doctor.Name} excluído com sucesso!");
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
