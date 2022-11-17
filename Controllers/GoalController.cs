using GoalHabitAPI.Services.GoalService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace GoalHabitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GoalDto>>> GetAllGoals()
        {
            return Ok(await _goalService.GetUserGoals());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GoalSelectedDto>> GetGoal(Guid id)
        {
            var result = await _goalService.GetGoal(id);

            if (result == null)
                return NotFound("Goal does not exist.");

            return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult<List<Goal>>> AddGoal(GoalAddDto goal)
        { 
            return await _goalService.AddGoal(goal); ;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Goal>> UpdateGoal(Guid id, GoalDto request)
        {
            var result = await _goalService.UpdateGoal(id, request);

            if (result == null)
                return NotFound("Goal does not exist.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<GoalDto>>> DeleteGoal(Guid id)
        {
            var result = await _goalService.DeleteGoal(id);

            if (result == null)
                return NotFound("Goal does not exist.");

            return Ok(result);
        }
    }
}
