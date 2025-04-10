using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories.Doctors;
using ProConsulta.Repositories.Specialitys;

namespace ProConsulta.Components.Pages.Doctors
{
    public class UpdateDoctorPage : ComponentBase
    {
        [Parameter]
        public int DoctorId { get; set; }

        [Inject]
        public ISpecialitysRepository specialitysRepository { get; set; } = null!;

        [Inject]
        public IDoctorRepository doctorRepository { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public Doctor? CurrentDoctor { get; set; } = null!;
        public DoctorInputModel InputModel = new DoctorInputModel();
        public List<Speciality> Specialities = new List<Speciality>();

        protected override async Task OnInitializedAsync()
        {
            CurrentDoctor = await doctorRepository.GetByIdAsync(DoctorId);
            Specialities = await specialitysRepository.GetAllAsync();

            if (CurrentDoctor is null) return;

            InputModel = new DoctorInputModel
            {
                Name = CurrentDoctor.Name,
                Documents = CurrentDoctor.Documents,
                Crm = CurrentDoctor.Crm,
                Phone = CurrentDoctor.Phone,
                SpecialtyId = CurrentDoctor.SpecialtyId
            };
        }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (CurrentDoctor is null) return;

                if(editContext.Model is DoctorInputModel model)
                {
                    CurrentDoctor.Id = DoctorId;
                    CurrentDoctor.Name = model.Name;
                    CurrentDoctor.Documents = model.Documents.CharactersOnly();
                    CurrentDoctor.Crm = model.Crm.CharactersOnly();
                    CurrentDoctor.Phone = model.Phone.CharactersOnly();
                    CurrentDoctor.SpecialtyId = model.SpecialtyId;

                    await doctorRepository.UpdateAsync(CurrentDoctor);
                    Snackbar.Add($"Médico {CurrentDoctor.Name} atualizado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/doctors");
                }
            }
            catch(Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

    }
}
