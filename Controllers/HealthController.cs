using GetFit_Application.Data;
using System.Linq;
using GetFit_Application.Models;
using GetFit_Application.Controllers;
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
            _context = context;        }

         //Responsible for displaying main index view 
        public IActionResult Index()
        {
            //Including the viewModel properties to include multi modeling inside Views 
            var diets = _context.Diets.ToList();
            var workouts = _context.Workouts.ToList();
            var viewModel = new GymViewModel
            {
                Diets = diets,
                Workouts = workouts
            };
            return View(viewModel);

        }

        //Reponsible for listing all diets within db 
        public async Task<IActionResult> GetDiets()
        {
            var diets = await _context.Diets.ToListAsync();
            return View(diets);

        }


        //Responsible for listing all workouts within the db
        public async Task<IActionResult> GetWorkouts()
        {
            var workouts = await _context.Workouts.ToListAsync();
            return View(workouts);

        }

        //Finds details for a single diet by id
        public async Task<IActionResult> GetDietDetils(int Id)
        {
            var diet = await _context.Diets.FirstOrDefaultAsync();
            if (diet == null)
            {
                return NotFound();

            }
            return View(diet);
        }

        //Retrieve a single workout by id
        [HttpGet]
        public async Task<IActionResult> GetSingleWorkoutDetails (int id)
        {
            var workout = await _context.Workouts.FirstOrDefaultAsync(w => w.Id == id);
            if(workout == null)
            {
                return NotFound();
            }
            return View(workout);
        }

       //Create a Diet entry
        [HttpGet]
        public  async Task<IActionResult> CreateDiet()
        {
            return View();


        }

        //Create Diet *Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDiet(Diet diet)
        {
            if (ModelState.IsValid)
            {
                _context.Diets.Add(diet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Diet));
            }
            return View(diet);
        }

        //Create a Workout entry
        public async Task<IActionResult> CreateWorkout()
        {
            return View();
        }


        //Create Workout *Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWorkout(Workout workout)
        {
            if (ModelState.IsValid)
            {
                _context.Workouts.Add(workout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Workout));
            }
            return View(workout);
        }


        // EDIT DIET
        [HttpGet]
        public async Task<IActionResult> EditDiet(int id)
        {
            var diet = await _context.Diets.FindAsync(id);
            if (diet == null)
                return NotFound();
            return View(diet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDiet(int id, Diet diet)
        {
            if (id != diet.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _context.Entry(diet).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GetDiets));
            }
            return View(diet);
        }

        // DELETE DIET
        [HttpGet]
        public async Task<IActionResult> DeleteDiet(int id)
        {
            var diet = await _context.Diets.FindAsync(id);
            if (diet == null)
                return NotFound();
            return View(diet);
        }

        [HttpPost, ActionName("DeleteDiet")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDietConfirmed(int id)
        {
            var diet = await _context.Diets.FindAsync(id);
            if (diet != null)
            {
                _context.Diets.Remove(diet);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(GetDiets));
        }

        // EDIT WORKOUT
        [HttpGet]
        public async Task<IActionResult> EditWorkout(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
                return NotFound();
            return View(workout);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditWorkout(int id, Workout workout)
        {
            if (id != workout.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _context.Entry(workout).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GetWorkouts));
            }
            return View(workout);
        }

        // DELETE WORKOUT
        [HttpGet]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
                return NotFound();
            return View(workout);
        }

        [HttpPost, ActionName("DeleteWorkout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteWorkoutConfirmed(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout != null)
            {
                _context.Workouts.Remove(workout);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(GetWorkouts));
        }
    }
}
