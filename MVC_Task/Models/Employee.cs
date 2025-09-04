namespace MVC_Task.Models
{
  
    
        public class Employee
        {
            public int Id { get; set; }          // PK
            public string Name { get; set; }
            public int Age { get; set; }
            public string Position { get; set; }
            public decimal Salary { get; set; }

            // Foreign Key
            public int DepartmentId { get; set; }

            // Navigation Property
            public Department Department { get; set; }
        }
    }


