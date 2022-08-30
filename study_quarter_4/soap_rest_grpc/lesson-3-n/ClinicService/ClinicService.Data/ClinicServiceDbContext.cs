using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicService.Data
{
    public class ClinicServiceDbContext : DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Consultation> Consultations { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountSession> AccountSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Consultation>()
                .HasOne(p => p.Pet)
                .WithMany(c => c.Consultation)
                .HasForeignKey(p => p.PetId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public ClinicServiceDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
