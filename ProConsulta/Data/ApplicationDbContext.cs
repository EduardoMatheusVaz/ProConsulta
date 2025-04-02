using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProConsulta.Models;
using System.Reflection;

namespace ProConsulta.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Scheduling> Schedulings { get; set; }
        public DbSet<Speciality> Specialitys { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) // método que faz a leitura das configurações e que os traga para o nosso banco de dados ao ser iniciada a aplicaçãpo
        {
            base.OnModelCreating(builder);
            
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            new DbInitializer(builder).seed(); // graças a ele, quando eu rodar o meu banco de dados ele já vai iniciar com alguns dados 
        }
    }
}
