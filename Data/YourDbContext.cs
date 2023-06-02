using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using testPFA.Models;

namespace testPFA.Data
{
    public class YourDbContext : DbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
        {

        }
        public DbSet<Loueur> Loueurs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ModeleDeVoiture> ModelesDeVoiture { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<Saison> Saisons { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       // {
          //  if (!optionsBuilder.IsConfigured)
           // {
              //  IConfigurationRoot configuration = new ConfigurationBuilder()
                //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                   // .AddJsonFile("appsettings.json")
                  //  .Build();

             //   optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
          //  }
       // }

    }

}
