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

        public DbSet<UserCase> UserCases { get; set; }

        public DbSet<UserMeeting> UserMeetings { get; set; }

        public AbogadoDbContext(DbContextOptions<AbogadoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //nombre de esquema
            modelBuilder.HasDefaultSchema("ABOGADO");
        }
    }
}
