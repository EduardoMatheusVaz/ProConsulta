using ProConsulta.Data;

namespace ProConsulta.Models
{
    public class Attendant : ApplicationUser // Estou usando este pois ele herda de Identity User, e nisso digo que meu atendente herda todas as propriedades de Identity User, e assim vou ter acesso a todas as propriedades do Identity
    {
        public string Name { get; set; }

    }
}
