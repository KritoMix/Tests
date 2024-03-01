using Microsoft.EntityFrameworkCore;
using Server.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data
{
    public class DataContext : DbContext
    {
        public DbSet<DataObject> dataObject { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.Entity<DataObject>()
                .Property(d => d.Id)
                .IsRequired()
            .ValueGeneratedOnAdd();

            optionsBuilder.Entity<DataObject>()
                .Property(d => d.Code)
                .IsRequired();

            optionsBuilder.Entity<DataObject>()
                .Property(d => d.Value)
                .IsRequired();
        }
    }
}
