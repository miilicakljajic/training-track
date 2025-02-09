using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using training_track_backend.DTOs;
using training_track_backend.Models;
using training_track_backend.Services;

namespace training_track_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;
        
        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<TrainingDTO?>> CreateTraining([FromBody]TrainingDTO training)
        {
            var userId = User.Claims.ElementAt(0).Value;
            training.UserId = Convert.ToInt32(userId);

            return Ok(await _trainingService.CreateTraining(training));
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<TrainingDTO>?>> GetTrainingsByUserId()
        {
            var userId = Convert.ToInt32(User.Claims.ElementAt(0).Value);

            return Ok(await _trainingService.GetTrainingsByUserId(userId));
        }

        [HttpGet("/month/{month}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<WeekDTO>?>> GetTrainingsPerWeek([FromRoute]int month)
        {
            var userId = Convert.ToInt32(User.Claims.ElementAt(0).Value);

            return Ok(await _trainingService.GetTrainingsPerWeek(userId, month));
        }
    }
}
