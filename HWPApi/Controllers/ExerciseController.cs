using HWPApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HWPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly ExerciseService _excersizeService;

        public ExerciseController(ExerciseService excersizeService)
        {
            _excersizeService = excersizeService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_excersizeService.GetAll());
        }
    }
}
