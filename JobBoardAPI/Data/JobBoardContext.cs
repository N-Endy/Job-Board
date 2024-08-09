using JobBoardAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardAPI.Data;

public class JobBoardContext : DbContext
{
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<JobPost> JobPosts { get; set; }

    public JobBoardContext(DbContextOptions<JobBoardContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasMany(s => s.JobPosts)
                .WithOne(j => j.Staff)
                .HasForeignKey(j => j.StaffId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(s => s.UserName)
                .IsUnique();
        });

        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasMany(a => a.Applications)
                .WithOne(j => j.Applicant)
                .HasForeignKey(j => j.ApplicantId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasOne(a => a.JobPost)
                .WithMany(j => j.Applications)
                .HasForeignKey(a => a.JobPostId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(a => a.Applicant)
                .WithMany(a => a.Applications)
                .HasForeignKey(a => a.ApplicantId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(a => a.AssignedStaff)
                .WithMany()
                .HasForeignKey(a => a.AssignedStaffId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<JobPost>(entity =>
        {
            entity.HasOne(j => j.Staff)
                .WithMany(s => s.JobPosts)
                .HasForeignKey(j => j.StaffId)
                .OnDelete(DeleteBehavior.NoAction);
        });
    }

}