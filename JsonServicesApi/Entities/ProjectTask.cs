namespace JsonServicesApi.Entities
{
    public class ProjectTask
    {
        private static int _seed = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        public ProjectTask()
        {
        }
        public ProjectTask(string name, string description, int employeeId, int projectID)
        {
            Id = _seed;
            Name = name;
            Description = description;
            EmployeeId = employeeId;
            ProjectId = projectID;
        }
        
    }
}
