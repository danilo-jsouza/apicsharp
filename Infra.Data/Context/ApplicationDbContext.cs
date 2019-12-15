using Domain.Interface;
using Domain.Models;
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

        public DbSet<Company> Company { get; set; }
        public DbSet<Freelancer> Freelancer { get; set; }
        public DbSet<HomeOffice> HomeOffice { get; set; }
        public DbSet<PhysicalPerson> PhysicalPerson { get; set; }

        private void ConfigureEntities(ModelBuilder modelBuilder)
        {
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