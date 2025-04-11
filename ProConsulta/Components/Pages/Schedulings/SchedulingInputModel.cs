using ProConsulta.Models;
using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Schedulings
{
    public class SchedulingInputModel
    {
        
        [MaxLength(250, ErrorMessage ="O campo {0} deve conter no máximo {1} caracteres")]
        public string? Observation { get; set; }

        [Required(ErrorMessage ="O Id do paciente deve ser fornecido!")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage ="O Id fornecido é inválido!")]
        public int PacientId { get; set; }

        [Required(ErrorMessage ="O Id do médico deve ser fornecido!")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "O Id fornecido é inválido!")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage ="A hora da consulta deve ser fornecida!")]
        public TimeSpan ConsultationTime { get; set; }

        [Required(ErrorMessage = "A data da consulta deve ser fornecida!")]
        public DateTime ConsultationDate { get; set; }

    }
}
