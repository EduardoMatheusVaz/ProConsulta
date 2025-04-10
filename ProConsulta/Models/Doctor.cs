namespace ProConsulta.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Documents { get; set; }
        public string Crm { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Phone { get; set; } = null!;
        public int SpecialtyId { get; set; }


        public Speciality Specialty { get; set; } = null!;
        public ICollection<Scheduling> Scheduling { get; set; } = new List<Scheduling>();
    }
}
