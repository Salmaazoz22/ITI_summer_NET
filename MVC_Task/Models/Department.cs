namespace MVC_Task.Models
{
    public class Department
    {
        public int Id { get; set; }          // PK
        public string Name { get; set; }     // Department Name

        // Navigation Property
        public List<Employee> Employees { get; set; }
    }
}
