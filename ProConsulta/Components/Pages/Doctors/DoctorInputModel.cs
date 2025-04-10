using ProConsulta.Models;
using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Doctors
{
    public class DoctorInputModel
    {

        public int Id { get; set; }
        
        [Required(ErrorMessage ="Nome deve ser fornecido!")]
        [MaxLength(50, ErrorMessage ="{0} deve conter no máximo {1} caracteres")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Documento deve ser fornecido!")]
        public string Documents { get; set; } = null!;

        [Required(ErrorMessage = "CRM deve ser fornecido!")]
        public string Crm { get; set; } = null!;

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Telefone deve ser fornecido!")]
        public string Phone { get; set; } = null!;
        
        [Required(ErrorMessage = "Especialidade deve ser fornecida!")]
        [RegularExpression("^(10|[1-9])$", ErrorMessage = "Valor selecionado é inválido!")]
        public int SpecialtyId { get; set; }

    }
}
