using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Patients
{
    public class PatientInputModel
    {
            
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome deve ser informado!")]
        [MaxLength(50, ErrorMessage = "{0} deve ter no máximo {1} caracteres}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Documento deve ser fornecido!")]
        public string Document { get; set; }

        [Required(ErrorMessage = "E-mail deve ser fornecido!")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [MaxLength(50, ErrorMessage = "{0} deve ter no máximo {1} caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Celular deve ser fornecido!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Data de nascimento deve ser fornecida!")]
        public DateTime DateBirth { get; set; } = DateTime.Today;
    }
}
