using Inz.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inz.Areas.Identity.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new AppUserEntityConfig());

    }

    public DbSet<Visit> Visits { get; set; }

    public DbSet<AppUser> AspNetUsers { get; set; }

    public DbSet<Patient> Patients { get; set; }

    public DbSet<VisitSummary> visitSummary { get; set; }

    public DbSet<Information> Informations { get; set; }

    public DbSet<InterviewModel> Interviews { get; set; }
  
}
