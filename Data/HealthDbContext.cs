using GetFit_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace GetFit_Application.Data
{
    public class HealthDbContext : DbContext
    {
        public HealthDbContext(DbContextOptions<HealthDbContext> options) : base(options)  {  }
        //Sepersate the models so that each database is interacted with independently
       public DbSet<Diet> Diets { get; set; }
       public DbSet<Workout> Workouts { get; set; }
    }
}
   