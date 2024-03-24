using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Persistence.Configuration;

internal class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.HasData(new LeaveType
        {
            Id = 1,
            Name = "Vacation",
            DefaultDays = 10,
            CreatedOn = DateTime.UtcNow,
            ModifiedOn = DateTime.UtcNow
        });

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
