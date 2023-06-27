using Microsoft.EntityFrameworkCore;
using RestoranDataBase.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDataBase.MigrationData
{
     public class DBContext : DbContext

    {
        public DbSet<Buyurtmalar> Buyurtmalar { get; set; }
        public DbSet<Menu> Menu { get; set; } 
        public DbSet<Users> Users { get; set; } 


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server = localhost; User id = postgres; Password = 12345678mn; Database = restoran");
        }

    }
}
