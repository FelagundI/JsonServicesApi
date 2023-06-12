using JsonServicesApi.Entities;
using System.Text.Json;

namespace JsonServicesApi.Data
{
    public class ProjectDataService
    {
        private IConfiguration _configuration;
        private string _jsonPath;
        public ProjectDataService(IConfiguration configuration)
        {
            _configuration = configuration;
            _jsonPath = _configuration["JsonPaths:ProjectPath"];
        }
        public List<Project>? GetAll()
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
            List<Project>? projects = JsonSerializer.Deserialize<List<Project>>(json);
            return projects;
        }
        public void Write(Project project)
        {
            List<Project>? projects = GetAll();
            if (projects == null)
            {
                projects = new List<Project>(); 
            }
            projects.Add(project);
            string json = JsonSerializer.Serialize(projects);
            File.WriteAllText(_jsonPath, json);
        }
    }
}
