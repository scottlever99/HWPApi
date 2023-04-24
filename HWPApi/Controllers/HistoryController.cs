using HWPApi.Data.Models;
using HWPApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HWPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private HistoryService _historyService;

        public HistoryController(HistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet("User/{id}")]
        public IActionResult User([FromRoute]int id)
        {
            if (id < 1) return BadRequest();

            var histories = _historyService.GetHistoryForUser(id);
            if (histories.Count < 1) return BadRequest();

            return Ok(histories);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] History history)
        {
            bool result = _historyService.Create(history);
            if (result) return Ok(result);

            return BadRequest();
        }
    }
}
