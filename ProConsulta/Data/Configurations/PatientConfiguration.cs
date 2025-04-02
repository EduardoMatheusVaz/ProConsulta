using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder) // Essa é a parte em que fazemos o mapeamento das nossas entidades, transformando elas em colunas no nosso banco de dados
        {

            builder.ToTable("Patients");

            builder.HasKey(i => i.Id); // Chave Primária

            builder.Property(n => n.Name)
                .IsRequired(true)
                .HasColumnType("VARCHAR(50)");

            builder.Property(d => d.Documents)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(11)");

            builder.Property(e => e.Email)
                .IsRequired(true)
                .HasColumnType("VARCHAR(50)");

            builder.Property(p => p.Phone)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(11)");

            builder.HasIndex(d => d.Documents)
                .IsUnique(); // Isso garante que caso tentarmos cadastrar dois pacientes com o mesmo CPF teremos erro, ele garante que seja somente uma daquela informação no nosso banco de dados

            builder.HasMany(s => s.Scheduling)
                .WithOne(a => a.Patient)
                .HasForeignKey(p => p.PatientId)  // esse valor ele vai pegar da table Scheduling
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
