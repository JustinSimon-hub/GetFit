using GetFit_Application.Data;
using GetFit_Application.Models;
using GetFit_Application.
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GetFit_Application.Controllers
{
    public class HealthController : Controller
    {
        private readonly HealthDbContext _context;
        public HealthController(HealthDbContext context)
        {
            _context = context;
        }

         //Responsible for displaying main index view 
        public IActionResult Index()
        {
            return View();

        }

        //Reponsible for listing all diets within db 
        public async Task<IActionResult> Diets()
        {
            var diets = await _context.Diets.ToListAsync();
            return View(diets);

        }


        //Responsible for listing all workouts within the db
        public async Task<IActionResult> Workouts()
        {
            var workouts = await _context.Workouts.ToListAsync();
            return View(workouts);

        }
    }
}
