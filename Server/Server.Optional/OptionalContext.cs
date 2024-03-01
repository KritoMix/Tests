using Microsoft.EntityFrameworkCore;
using Server.Optional.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Optional
{
    public class OptionalContext : DbContext
    {
        public DbSet<DateEntry> dates { get; set; }

        public OptionalContext(DbContextOptions<OptionalContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.Entity<DateEntry>()
                .Property(d => d.Id)
                .IsRequired()
            .ValueGeneratedOnAdd();

            optionsBuilder.Entity<DateEntry>()
                .Property(d => d.Dt)
                .IsRequired();
        }
    }
}
