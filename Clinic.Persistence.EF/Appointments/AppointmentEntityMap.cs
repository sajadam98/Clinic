using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DoctorPatientEntityMap : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> _)
    {
        _.ToTable("Appointments");
        _.HasKey(p => p.Id);
        _.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        _.Property(p => p.Date).IsRequired();
        _.HasOne(p => p.Doctor).WithMany(p => p.DoctorPatients)
            .HasForeignKey(p => p.DoctorId);
        _.HasOne(p => p.Patient).WithMany(p => p.PatientDoctors)
            .HasForeignKey(p => p.DoctorId);
    }
}