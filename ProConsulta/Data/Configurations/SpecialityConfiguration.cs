using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations
{
    public class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
    {
        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            builder.ToTable("Specialitys");

            builder.HasKey(i => i.Id);

            builder.Property(n => n.Name)
                .IsRequired(true)
                .HasColumnType("VARCHAR(60)");

            builder.Property(d => d.Description)
                .IsRequired(false)
                .HasColumnType("VARCHAR(150)");

            builder.HasMany(d => d.Doctors)
                .WithOne(s => s.Specialty)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
