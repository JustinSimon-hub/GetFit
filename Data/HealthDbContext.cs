using GetFit_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace GetFit_Application.Data
{
    public class HealthDbContext : DbContext
    {
        public HealthDbContext(DbContextOptions<HealthDbContext> options) : base(options)  {  }
        //Sepersate the models so that each database is interacted with independently
        DbSet<Diet> Diets { get; set; }
        DbSet<Workout> Workouts { get; set; }
    }
}
   