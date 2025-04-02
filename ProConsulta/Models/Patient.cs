namespace ProConsulta.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Documents { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateBirth { get; set; }


        public ICollection<Scheduling> Scheduling { get; set; } = new List<Scheduling>();
    }
}
