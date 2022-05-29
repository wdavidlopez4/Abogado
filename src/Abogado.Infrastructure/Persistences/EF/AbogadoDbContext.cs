using Abogado.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Infrastructure.Persistences.EF
{
    public class AbogadoDbContext : DbContext
    {
        public DbSet<Case> Cases { get; set; }

        public DbSet<FileDocument> Files { get; set; }

        public DbSet<Meeting> Meetings { get; set; }

        public DbSet<User> Users { get; set; }


        public AbogadoDbContext(DbContextOptions<AbogadoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //nombre de esquema
            modelBuilder.HasDefaultSchema("ABOGADO");

            modelBuilder.Entity<Case>()
                .Property(p => p.Id)
                .HasColumnType("varchar");

            modelBuilder.Entity<Case>()
                .Property(p => p.FileId)
                .HasColumnType("varchar");

            modelBuilder.Entity<User>()
                .Property(p => p.Id)
                .HasColumnType("varchar");

            modelBuilder.Entity<FileDocument>()
                .Property(p => p.Id)
                .HasColumnType("varchar");

            modelBuilder.Entity<Meeting>()
                .Property(p => p.Id)
                .HasColumnType("varchar");
        }
    }
}
