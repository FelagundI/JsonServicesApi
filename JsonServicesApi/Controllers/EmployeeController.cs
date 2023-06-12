using JsonServicesApi.Data;
using JsonServicesApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JsonServicesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private ILogger<EmployeeController> _logger;
        private readonly EmployeeDataService _dataService;
        public EmployeeController(ILogger<EmployeeController> logger, EmployeeDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Get Employee/GetAll");
            return Ok(_dataService.GetAll());
        }
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            _logger.LogInformation($"POST Employee {employee.Id}");
            if(employee.Id == 0)
            {
                employee = new Employee(employee.Name);
            }
            _dataService.Write(employee);
            return Ok(employee);
        }
        [HttpPut]
        public IActionResult Put(Employee employee)
        {
            _logger.LogInformation($"PUT Employee/{employee.Id}");
            Employee? emp = _dataService.GetAll().SingleOrDefault(c =>  c.Id == employee.Id);
            if(emp == null)
            {
                _logger.LogWarning($"{employee.Id} not found");
                return BadRequest();
            }
            emp.Name = employee.Name;
            return Ok(emp);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"DELETE Employee/{id}");
            Employee? empl = _dataService.GetAll().SingleOrDefault(c => c.Id == id);
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
