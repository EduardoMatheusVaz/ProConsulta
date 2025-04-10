using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories.Doctors;
using ProConsulta.Repositories.Specialitys;

namespace ProConsulta.Components.Pages.Doctors
{
    public class CreateDoctorPage : ComponentBase
    {
        [Inject]
        private ISpecialitysRepository SpecialitysRepository { get; set; } = null!;

        [Inject]
        private IDoctorRepository DoctorRepository { get; set; } = null!;

        [Inject]
        private ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        public List<Speciality> Specialities { get; set; } = new List<Speciality>();
        public DoctorInputModel InputModel { get; set; } = new DoctorInputModel();

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if(editContext.Model is DoctorInputModel model) // validamos se o Model do nosso edicontext é o mesmo tipo do nosso DoctorInputModel que estamos chamando de model
                {
                    var doctor = new Doctor
                    {
                        Name = model.Name,
                        Documents = model.Documents.CharactersOnly(),
                        Crm = model.Crm.CharactersOnly(),
                        Phone = model.Phone.CharactersOnly(),
                        SpecialtyId = model.SpecialtyId,
                        RegistrationDate = model.RegistrationDate
                    };

                    await DoctorRepository.AddAsync(doctor);
                    Snackbar.Add("Médico cadastrado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/doctors");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Specialities = await SpecialitysRepository.GetAllAsync();
        }

    }
}
