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
    public class WorkoutTaskController : ControllerBase
    {
        private readonly HWPDatabase _context;

        public WorkoutTaskController(HWPDatabase context)
        {
            _context = context;
        }

        // GET: api/WorkoutTask
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutTask>>> GetWorkoutTask()
        {
          if (_context.WorkoutTask == null)
          {
              return NotFound();
          }
            return await _context.WorkoutTask.ToListAsync();
        }

        // GET: api/WorkoutTask/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutTask>> GetWorkoutTask(int id)
        {
          if (_context.WorkoutTask == null)
          {
              return NotFound();
          }
            var workoutTask = await _context.WorkoutTask.FindAsync(id);

            if (workoutTask == null)
            {
                return NotFound();
            }

            return workoutTask;
        }

        // PUT: api/WorkoutTask/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkoutTask(int id, WorkoutTask workoutTask)
        {
            if (id != workoutTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(workoutTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutTaskExists(id))
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

        // POST: api/WorkoutTask
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkoutTask>> PostWorkoutTask(WorkoutTask workoutTask)
        {
          if (_context.WorkoutTask == null)
          {
              return Problem("Entity set 'HWPDatabase.WorkoutTask'  is null.");
          }
            _context.WorkoutTask.Add(workoutTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkoutTask", new { id = workoutTask.Id }, workoutTask);
        }

        // DELETE: api/WorkoutTask/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutTask(int id)
        {
            if (_context.WorkoutTask == null)
            {
                return NotFound();
            }
            var workoutTask = await _context.WorkoutTask.FindAsync(id);
            if (workoutTask == null)
            {
                return NotFound();
            }

            _context.WorkoutTask.Remove(workoutTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkoutTaskExists(int id)
        {
            return (_context.WorkoutTask?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
