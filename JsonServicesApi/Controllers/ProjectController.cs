using JsonServicesApi.Data;
using JsonServicesApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JsonServicesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private ILogger<ProjectController> _logger;
        private readonly ProjectDataService _dataService;
        public ProjectController(ILogger<ProjectController> logger, ProjectDataService dataService)
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
        public IActionResult Post(Project project)
        {
            _logger.LogInformation($"POST Project {project.Id}");
            if (project.Id == 0)
            {
                project = new Project(project.Title, project.Description);
            }
            _dataService.Write(project);
            return Ok(project);
        }
        [HttpPut]
        public IActionResult Put(Project project)
        {
            _logger.LogInformation($"PUT Project/{project.Id}");
            Project? pro = _dataService.GetAll().SingleOrDefault(c => c.Id == project.Id);
            if(pro == null)
            {
                _logger.LogWarning($"{project.Id} not found");
                return BadRequest();
            }
            pro.Title = project.Title;
            return Ok(pro);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"DELETE Project/{id}");
            Project? empl = _dataService.GetAll().SingleOrDefault(c => c.Id == id);
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
