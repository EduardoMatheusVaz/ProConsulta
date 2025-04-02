using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations
{
    public class SchedulingConfiguration : IEntityTypeConfiguration<Scheduling>
    {
        public void Configure(EntityTypeBuilder<Scheduling> builder)
        {
            builder.ToTable("Schedulings");

            builder.HasKey(i => i.Id);

            builder.Property(o => o.Observation)
                .IsRequired(false)
                .HasColumnType("VARCHAR(250)");

            builder.Property(p => p.PatientId)
                .IsRequired(true);

            builder.Property(d => d.DoctorId)
                .IsRequired(true);
        }
    }
}
