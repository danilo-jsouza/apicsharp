using Domain.Interface;
using Domain.Models;
using Domain.Models.Adress;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        #region DbSet
        public DbSet<Company> Company { get; set; }
        public DbSet<Freelancer> Freelancer { get; set; }
        public DbSet<HomeOffice> HomeOffice { get; set; }
        public DbSet<PhysicalPerson> PhysicalPerson { get; set; }
        public DbSet<CompanyAdress> CompanyAdresses { get; set; }
        public DbSet<FreelancerAdress> FreelancerAdresses { get; set; }
        public DbSet<HomeOfficeAdress> HomeOfficeAdresses { get; set; }
        public DbSet<PhysicalPersonAdress> PhysicalPersonAdresses { get; set; }
        #endregion

        private void ConfigureEntities(ModelBuilder modelBuilder)
        {
            #region RelationShip
            modelBuilder.Entity<CompanyAdress>(companyAdresses =>
            {
                companyAdresses
                    .HasOne(comAdr => comAdr.Company)
                    .WithOne(com => com.CompanyAdress);
            });

            modelBuilder.Entity<FreelancerAdress>(freelancerAdresses =>
            {
                freelancerAdresses
                    .HasOne(freeAdr => freeAdr.Freelancer)
                    .WithOne(free => free.FreelancerAdress);
            });

            modelBuilder.Entity<HomeOfficeAdress>(homeOfficeAdresses =>
            {
                homeOfficeAdresses
                    .HasOne(homeAdr => homeAdr.HomeOffice)
                    .WithOne(hom => hom.HomeOfficeAdress);
            });

            modelBuilder.Entity<PhysicalPersonAdress>(physicalPersonAdresses =>
            {
                physicalPersonAdresses
                    .HasOne(phyPerAdr => phyPerAdr.PhysicalPerson)
                    .WithOne(phyPer => phyPer.PhysicalPersonAdress);
            });
            #endregion

            #region ConfigureEntities
            modelBuilder.Entity<Company>(company =>
            {
                company.HasKey(com => com.Id);
                company.Property(com => com.CompanyName).HasMaxLength(100);
                company.Property(com => com.FantasyName).HasMaxLength(100);
                company.Property(com => com.Cnpj).HasMaxLength(14);
                company.HasIndex(com => com.Cnpj).IsUnique();
            });

            modelBuilder.Entity<Freelancer>(freelancer =>
            {
                freelancer.HasKey(fr => fr.Id);
                freelancer.Property(fr => fr.Name).HasMaxLength(100);
                freelancer.Property(fr => fr.Cpf).HasMaxLength(11);
                freelancer.HasIndex(fr => fr.Cpf).IsUnique();
                freelancer.Property(fr => fr.Sexo).HasColumnType("enum('male', 'female')");
            });

            modelBuilder.Entity<HomeOffice>(homeOffice =>
            {
                homeOffice.HasKey(hom => hom.Id);
                homeOffice.Property(hom => hom.Name).HasMaxLength(100);
                homeOffice.Property(hom => hom.Cpf).HasMaxLength(11);
                homeOffice.HasIndex(hom => hom.Cpf).IsUnique();
                homeOffice.Property(hom => hom.Sexo).HasColumnType("enum('male', 'female')");
            });

            modelBuilder.Entity<PhysicalPerson>(physicalPerson =>
            {
                physicalPerson.HasKey(phy => phy.Id);
                physicalPerson.Property(phy => phy.Name).HasMaxLength(100);
                physicalPerson.Property(phy => phy.Sexo).HasColumnType("enum('male', 'female')");
                physicalPerson.Property(phy => phy.Cpf).HasMaxLength(11);
                physicalPerson.HasIndex(phy => phy.Cpf).IsUnique();
            });

            modelBuilder.Entity<CompanyAdress>(companyAdress =>
            {
                companyAdress.HasKey(comAdr => comAdr.Id);
                companyAdress.Property(comAdr => comAdr.City).HasMaxLength(65);
                companyAdress.Property(comAdr => comAdr.State).HasMaxLength(65);
            });

            modelBuilder.Entity<FreelancerAdress>(freelancerAdress =>
            {
                freelancerAdress.HasKey(freeAdr => freeAdr.Id);
                freelancerAdress.Property(freeAdr => freeAdr.City).HasMaxLength(65);
                freelancerAdress.Property(freeAdr => freeAdr.State).HasMaxLength(65);
            });

            modelBuilder.Entity<HomeOfficeAdress>(homeOfficeAdress =>
            {
                homeOfficeAdress.HasKey(homAdr => homAdr.Id);
                homeOfficeAdress.Property(homAdr => homAdr.City).HasMaxLength(65);
                homeOfficeAdress.Property(homAdr => homAdr.State).HasMaxLength(65);
            });

            modelBuilder.Entity<HomeOfficeAdress>(homeOfficeAdress =>
            {
                homeOfficeAdress.HasKey(homAdr => homAdr.Id);
                homeOfficeAdress.Property(homAdr => homAdr.City).HasMaxLength(65);
                homeOfficeAdress.Property(homAdr => homAdr.State).HasMaxLength(65);
            });

            #endregion
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureEntities(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries<IModelBasic>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Active = true;
                        entry.Entity.CreatedAt = entry.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Deleted:
                        if (entry.Entity.IsVirtualDeleted)
                        {
                            entry.State = EntityState.Modified;
                            entry.Entity.Active = false;
                        }
                        break;
                }
            }
        }
    }
}