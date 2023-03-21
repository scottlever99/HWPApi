using HWPApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HWPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly HWPDatabase _context;

        public WorkoutController(HWPDatabase context)
        {
            _context = context;
        }

        // GET: api/<WorkoutController>
        [HttpGet]
        public ActionResult<List<Workout>> Get()
        {
            List<Workout> result = new();

            var plans = _context.WorkoutPlan.ToList();

            foreach(var plan in plans)
            {
                Workout workout = new Workout()
                {
                    Plan = plan,
                    Tasks = _context.WorkoutTask.Where(w => w.PlanId == plan.Id).ToList()
                };

                result.Add(workout);
            }

            return Ok(result);
        }

        // GET api/<WorkoutController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WorkoutController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WorkoutController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WorkoutController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
