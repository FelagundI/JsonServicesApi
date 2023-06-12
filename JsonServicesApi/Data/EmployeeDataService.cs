using JsonServicesApi.Entities;
using System.Text.Json;

namespace JsonServicesApi.Data
{
    public class EmployeeDataService
    {
        private IConfiguration _configuration;
        private string _jsonPath;
        public EmployeeDataService(IConfiguration configuration)
        {
            _configuration = configuration;
            _jsonPath = _configuration["JsonPaths:EmployeePath"];
        }
        public List<Employee>? GetAll()
        {
            string json = "[]";
            if (!File.Exists(_jsonPath))
            {
                File.WriteAllText(_jsonPath, json);
            }
            else
            {
                json = File.ReadAllText(_jsonPath);
            }
            List<Employee>? employees = JsonSerializer.Deserialize<List<Employee>>(json);
            return employees;
        }  
        public void Write(Employee employee)
        {
            List<Employee>? employees = GetAll();
            if(employees == null)
            {
                employees = new List<Employee>();
            }
            employees.Add(employee);
            string json = JsonSerializer.Serialize(employees);
            File.WriteAllText(_jsonPath, json);
        }
    }
}
