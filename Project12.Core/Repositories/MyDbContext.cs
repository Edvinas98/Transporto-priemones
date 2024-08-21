using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransportoPriemones.Core.Models;

namespace TransportoPriemones.Core.Repositories
{
    public class MyDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Lorry> Lorries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=vehicles;Trusted_Connection=true;TrustServerCertificate=True");
        }
    }
}
