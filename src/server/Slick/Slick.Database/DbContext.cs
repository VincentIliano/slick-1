using Microsoft.EntityFrameworkCore;
using Slick.Models.Contact;
using Slick.Models.Contracts;
using Slick.Models.People;
using Slick.Models.Skills;
using System;

namespace Slick.Database
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Specialisation> Specialisations { get; set; }
        public DbSet<ConsultantSpecialisation> ConsultantSpecialisations { get; set; }
        public DbSet<SpecialisationLevel> SpecialisationLevels { get; set; }
    }
}
