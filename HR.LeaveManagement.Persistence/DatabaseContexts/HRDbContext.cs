using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.DatabaseContexts;
internal class HRDatabaseContext : DbContext
{
    public HRDatabaseContext(DbContextOptions<HRDatabaseContext> options) : base(options)
    {

    }

    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HRDatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
            .Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified))
        {
            entry.Entity.ModifiedOn = DateTime.UtcNow;

            if(entry.State == EntityState.Added)
                entry.Entity.CreatedOn = DateTime.UtcNow;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
