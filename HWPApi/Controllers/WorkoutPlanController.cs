using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HWPApi;
using HWPApi.Models;

namespace HWPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutPlanController : ControllerBase
    {
        private readonly HWPDatabase _context;

        public WorkoutPlanController(HWPDatabase context)
        {
            _context = context;
        }

        // GET: api/WorkoutPlan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutPlan>>> GetWorkoutPlan()
        {
          if (_context.WorkoutPlan == null)
          {
              return NotFound();
          }
            return await _context.WorkoutPlan.ToListAsync();
        }

        // GET: api/WorkoutPlan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutPlan>> GetWorkoutPlan(int id)
        {
              if (_context.WorkoutPlan == null)
              {
                  return NotFound();
              }
            var workoutPlan = await _context.WorkoutPlan.FindAsync(id);

            if (workoutPlan == null)
            {
                return NotFound();
            }

            return workoutPlan;
        }

        // PUT: api/WorkoutPlan/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkoutPlan(int id, WorkoutPlan workoutPlan)
        {
            if (id != workoutPlan.Id)
            {
                return BadRequest();
            }

            _context.Entry(workoutPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutPlanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WorkoutPlan
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkoutPlan>> PostWorkoutPlan(WorkoutPlan workoutPlan)
        {
          if (_context.WorkoutPlan == null)
          {
              return Problem("Entity set 'HWPDatabase.WorkoutPlan'  is null.");
          }
            _context.WorkoutPlan.Add(workoutPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkoutPlan", new { id = workoutPlan.Id }, workoutPlan);
        }

        // DELETE: api/WorkoutPlan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutPlan(int id)
        {
            if (_context.WorkoutPlan == null)
            {
                return NotFound();
            }
            var workoutPlan = await _context.WorkoutPlan.FindAsync(id);
            if (workoutPlan == null)
            {
                return NotFound();
            }

            _context.WorkoutPlan.Remove(workoutPlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkoutPlanExists(int id)
        {
            return (_context.WorkoutPlan?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
