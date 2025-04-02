namespace ProConsulta.Models
{
    public class Speciality
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>(); // Estou usando o IList pois ele implementa o IColletion por baixo dos panos, e é uma coleção mais rica pois tem alguns métodos a mais
    }
}
