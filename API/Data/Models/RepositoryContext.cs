using Microsoft.EntityFrameworkCore;

namespace API.Data.Models;
public class RepositoryContext : DbContext
{
    public DbSet<Staff> Staffs { get; private set; }
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<JobPost> JobPosts { get; set; }
    public DbSet<Application> Applications { get; set; }

    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the unique index on Username for Staff
        modelBuilder.Entity<Staff>()
            .HasIndex(s => s.Username)
            .IsUnique();

        // Configure relationships to avoid multiple cascade paths
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasOne(a => a.JobPost)
                .WithMany(j => j.Applications)
                .HasForeignKey(a => a.JobPostId)
                .OnDelete(DeleteBehavior.NoAction);

            // entity.HasOne(a => a.Applicant)
            //     .WithMany(a => a.Applications)
            //     .HasForeignKey(a => a.ApplicantId)
            //     .OnDelete(DeleteBehavior.NoAction);

            // entity.HasOne(a => a.AssignedStaff)
            //     .WithMany()
            //     .HasForeignKey(a => a.StaffId)
            //     .OnDelete(DeleteBehavior.NoAction);
        });
    }
}