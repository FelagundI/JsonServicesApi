namespace JsonServicesApi.Entities
{
    public class Employee
    {
        private static int _seed = 0;
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee() 
        {

        }
        public Employee(string name)
        {
            Id = _seed++;
            Name = name;
        }
    }
}
