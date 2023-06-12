namespace JsonServicesApi.Entities
{
    public class Project
    {
        private static int _seed = 0;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Project() 
        { 

        }
        public Project(string title, string description)
        {
            Id = _seed++;
            Title = title;
            Description = description;
        }
        
    }
}
