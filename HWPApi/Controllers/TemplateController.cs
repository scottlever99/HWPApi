using HWPApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HWPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly TemplateService templateService;

        public TemplateController(TemplateService templateService)
        {
            this.templateService = templateService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(templateService.GetTemplates());
        }

        [HttpGet("User/{UserId}")]
        public ActionResult GetForUser([FromRoute] int UserId)
        {
            return Ok(templateService.GetTemplatesForUser(UserId));
        }
    }
}
