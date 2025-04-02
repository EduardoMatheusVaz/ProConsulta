using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");

            builder.HasKey(i => i.Id);

            builder.Property(n => n.Name)
                .IsRequired(true)
                .HasColumnType("VARCHAR(50)");

            builder.Property(d => d.Documents)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(11)");

            builder.Property(c => c.Crm)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(8)");

            builder.Property(p => p.Phone)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(11)");

            builder.Property(s => s.SpecialtyId)
                .IsRequired(true);

            builder.HasIndex(d => d.Documents)
                .IsUnique();

            builder.HasMany(s => s.Scheduling)
                .WithOne(d => d.Doctor)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
