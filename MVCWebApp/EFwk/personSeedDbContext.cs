using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCWebApp.Models.Person;


namespace MVCWebApp.EFwk
{
    public class personSeedDbContext:DbContext
    {
        public personSeedDbContext(DbContextOptions<personSeedDbContext> options) : base(options)
        {

        }

        public DbSet<personproperties> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<personproperties>().HasData(new personproperties { ID = 1, Name = "John Stwart", City = "Lund", PhoneNumber = "0786574567" });
            modelBuilder.Entity<personproperties>().HasData(new personproperties { ID = 2, Name = "Josefine Gustafsson", City = "Gothenburg", PhoneNumber = "0786544567" });
            modelBuilder.Entity<personproperties>().HasData(new personproperties { ID = 3, Name = "Andrew  Monnet", City = "Stockholm", PhoneNumber = "0786894567" });
        }
    }
}
