using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using plural.health.Domian.Models;
using plural.health.Infrastructure.ViewModel;

namespace plural.health.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>  //IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Patient> Patients => Set<Patient>()!;
        public DbSet<Appointment> Appointments => Set<Appointment>()!;
        public DbSet<Wallet> Wallets => Set<Wallet>()!;
        public DbSet<Transaction> transactions => Set<Transaction>()!;

        public virtual async Task<int> SaveChangesAsync(string? userId)
        {
            //OnBeforeSaveChanges(userId);
            var result = await base.SaveChangesAsync();
            return result;
        }

        public virtual int SaveChanges(string? userId)
        {
            //OnBeforeSaveChanges(userId);
            var result = base.SaveChanges();
            return result;
        }
    }
}
