using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Server.Clients.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Server.Clients
{
    public class ClientContext : DbContext
    {
        public DbSet<Client> clients { get; set; } 
        public DbSet<ClientContact> clientContacts { get; set; }
        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.Entity<Client>()
                .Property(c => c.ClientName)
                .IsRequired()
                .HasMaxLength(200);

            optionsBuilder.Entity<Client>()
                .Property(d => d.Id)
                .IsRequired()
            .ValueGeneratedOnAdd();

            optionsBuilder.Entity<ClientContact>()
                .Property(d => d.Id)
                .IsRequired()
            .ValueGeneratedOnAdd();
        }
    }
}
