using Microsoft.EntityFrameworkCore;
using SotatekTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotatekTest.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .Property(x => x.FullName).IsRequired();
            builder.Entity<User>()
                .Property(x => x.Email).IsRequired();
            builder.Entity<User>()
                .Property(x => x.Age).IsRequired(false);
            builder.Entity<User>()
                .Property(x => x.Phone).IsRequired(false);
            
        }
    }
}
