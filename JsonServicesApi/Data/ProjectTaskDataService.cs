using JsonServicesApi.Entities;
using System.Text.Json;

namespace JsonServicesApi.Data
{
    public class ProjectTaskDataService
    {
         private IConfiguration _configuration;
         private string _jsonPath;

         public ProjectTaskDataService(IConfiguration configuration)
         {
             _configuration = configuration;
             _jsonPath = _configuration["JsonPaths:ProjectTaskPath"];
         }
         public List<ProjectTask>? GetAll()
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
             List<ProjectTask>? projectsTask = JsonSerializer.Deserialize<List<ProjectTask>>(json);
             return projectsTask;
         }
         public void Write(ProjectTask projectTask)
         {
             List<ProjectTask>? projectsTask = GetAll();
             if (projectsTask == null)
             {
                 projectsTask = new List<ProjectTask>();
             }
             projectsTask.Add(projectTask);
             string json = JsonSerializer.Serialize(projectsTask);
             File.WriteAllText(_jsonPath, json);
            }
    }
}
