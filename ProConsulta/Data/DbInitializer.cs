using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProConsulta.Components.Pages;
using ProConsulta.Models;

namespace ProConsulta.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }
        internal void seed()
        {
            _modelBuilder.Entity<IdentityRole>().HasData
            (
                new IdentityRole
                {
                    Id = "04f1966f-0c94-4999-a602-d81ee9332fa7",
                    Name = "Atendente",
                    NormalizedName = "ATENDENTE"
                },
                new IdentityRole
                {
                    Id = "00011110-c371-499c-88bf-4faf4f57e9c9",
                    Name = "Medico",
                    NormalizedName = "MEDICO"
                }
            );

            var hasher = new PasswordHasher<IdentityUser>();

            _modelBuilder.Entity<Attendant>().HasData
             (
                 new Attendant
                 {
                     Id = "33f0ef9f-3d09-48ba-86d6-500a130e569c",
                     Name = "Pro Consulta",
                     Email = "proconsulta@gmail.com",
                     EmailConfirmed = true,
                     UserName = "proconsulta@gmail.com.br",
                     NormalizedEmail = "PROCONSULTA@GMAIL.COM.BR",
                     NormalizedUserName = "PROCONSULTA@GMAIL.COM.BR",
                     PasswordHash = hasher.HashPassword(null, "Pa$$word")
                 }
             );

            _modelBuilder.Entity<IdentityUserRole<string>>().HasData
             (
                new IdentityUserRole<string>
                {
                    RoleId = "04f1966f-0c94-4999-a602-d81ee9332fa7",
                    UserId = "33f0ef9f-3d09-48ba-86d6-500a130e569c"
                }
             );

            _modelBuilder.Entity<Speciality>().HasData
             (
                new Speciality { Id = 1, Name = "Cardiologia", Description = "Especialidade médica que cuida do coração" },
                new Speciality { Id = 2, Name = "Dermatologia", Description = "Especialidade que trata de doenças e condições da pele." },
                new Speciality { Id = 3, Name = "Ortopedia", Description = "Especialidade focada no tratamento de ossos, músculos ." },
                new Speciality { Id = 4, Name = "Pediatria", Description = "Área médica voltada ao cuidado da saúde infantil." },
                new Speciality { Id = 5, Name = "Ginecologia", Description = "Especialidade que trata da saúde do sistema reprodutor feminino." },
                new Speciality { Id = 6, Name = "Neurologia", Description = "Área da medicina que trata do sistema nervoso." },
                new Speciality { Id = 7, Name = "Psiquiatria", Description = "Especialidade que cuida da saúde mental e transtornos psicológicos." },
                new Speciality { Id = 8, Name = "Oftalmologia", Description = "Especialidade dedicada ao cuidado da visão e dos olhos." },
                new Speciality { Id = 9, Name = "Endocrinologia", Description = "Especialidade que trata das glândulas e hormônios do corpo." },
                new Speciality { Id = 10, Name = "Gastroenterologia", Description = "Área médica que cuida do sistema digestivo." }
             );

        }
    }
}
