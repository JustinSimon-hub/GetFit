using GetFit_Application.Data;
using GetFit_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GetFit_Application.Controllers
{
    public class HealthController : Controller
    {
        private readonly HealthDbContext _context;
        public HealthController(HealthDbContext context)
        {
            _context = context;
        }

        // INDEX
        public IActionResult Index()
        {
            var diets = _context.Diets.ToList();
            var workouts = _context.Workouts.ToList();

            var viewModel = new GymViewModel
            {
                Diets = diets,
                Workouts = workouts
            };

            return View(viewModel);
        }

        // ===== DIETS =====
        public async Task<IActionResult> GetDiets()
        {
            var diets = await _context.Diets.ToListAsync();
            return View(diets);
        }

        [HttpGet]
        public IActionResult CreateDiet()
        {
           return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiet(Diet diet)
        {
            if (ModelState.IsValid)
            {
                _context.Diets.Add(diet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diet);
        }

        // ===== WORKOUTS =====
        public async Task<IActionResult> GetWorkouts()
        {
            var workouts = await _context.Workouts.ToListAsync();
            return View(workouts);
        }

        [HttpGet]
        public IActionResult CreateWorkout()
        {
           return View();
        }

        [HttpPost]
     
        public async Task<IActionResult> CreateWorkout(Workout workout)
        {
            if (ModelState.IsValid)
            {
                _context.Workouts.Add(workout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workout);
        }
    }
}
