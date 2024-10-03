using DevFreela.Application.Commands.InsertSkill;
using DevFreela.Application.Queries.GetAllSkills;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        private readonly IMediator _mediator;
        public SkillsController(DevFreelaDbContext context, IMediator mediator)
        {
            _mediator = mediator;
            _context = context;
        }
        //GET api/skills
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllSkillsQuery());
            return Ok(result);
        }

        //POST api/skills
        [HttpPost]
        public async Task<IActionResult> Post(InsertSkillCommand command)
        {
           var result = await _mediator.Send(command);

            return NoContent();
        }
    }
}
