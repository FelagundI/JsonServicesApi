using JsonServicesApi.Data;
using JsonServicesApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JsonServicesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {

        private ILogger<ProjectTaskController> _logger;
        private readonly ProjectTaskDataService _dataService;
        public ProjectTaskController(ILogger<ProjectTaskController> logger, ProjectTaskDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Get Category/GetAll");
            return Ok(_dataService.GetAll());
        }
        [HttpPost]
        public IActionResult Post(ProjectTask projectTask)
        {
            _logger.LogInformation($"POST ProjectTask {projectTask.Id}");
           
            if(projectTask.Id == 0) 
            {
                projectTask = new ProjectTask(projectTask.Name, projectTask.Description, projectTask.EmployeeId, projectTask.ProjectId);
            }
            _dataService.Write(projectTask);
            return Ok(projectTask);
        }
        [HttpPut]
        public IActionResult Put(ProjectTask projectTask)
        {
            _logger.LogInformation($"PUT ProjectTask/{projectTask.Id}");
            ProjectTask? tas = _dataService.GetAll().SingleOrDefault(c => c.Id == projectTask.Id);
            if(tas == null)
            {
                _logger.LogWarning($"{projectTask.Id} not found");
                return BadRequest();
            }
            tas.Id = projectTask.Id;
            return Ok(tas);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"DELETE ProjectTask/{id}");
            ProjectTask? empl = _dataService.GetAll().SingleOrDefault(c => c.Id == id);
            if (empl == null)
            {
                _logger.LogWarning($"{id} not found");
                return BadRequest();
            }
            if (_dataService.GetAll().Remove(empl))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
