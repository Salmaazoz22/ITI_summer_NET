using System;

class Program
{
    class Employee
    {
        public int Id;
        public string Name;
        public int Age;
        public double Salary;
        public string Email;
    }

    static void Main()
    {
        Console.Write("Enter number of employees: ");
        int n = int.Parse(Console.ReadLine());
        Employee[] employees = new Employee[n];
        int count = 0;

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1 - Add Employee");
            Console.WriteLine("2 - Edit Employee by ID");
            Console.WriteLine("3 - Delete Employee by ID");
            Console.WriteLine("4 - Get All Employees");
            Console.WriteLine("0 - Exit");
            Console.Write("Choose: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 0:
                    return;

                case 1:
                    if (count >= n)
                    {
                        Console.WriteLine("Employee list is full.");
                        break;
                    }
                    Employee emp = new Employee
                    {
                        Id = ReadId(),
                        Age = ReadAge(),
                        Salary = ReadSalary(),
                        Name = ReadName(),
                        Email = ReadEmail()
                    };
                    employees[count] = emp;
                    count++;
                    Console.WriteLine("Employee added.");
                    break;

                case 2:
                    Console.Write("Enter ID to edit: ");
                    int editId = int.Parse(Console.ReadLine());
                    bool foundEdit = false;
                    for (int i = 0; i < count; i++)
                    {
                        if (employees[i].Id == editId)
                        {
                            employees[i].Age = ReadAge();
                            employees[i].Salary = ReadSalary();
                            employees[i].Name = ReadName();
                            employees[i].Email = ReadEmail();
                            Console.WriteLine("Employee updated.");
                            foundEdit = true;
                            break;
                        }
                    }
                    if (!foundEdit) Console.WriteLine("ID not found.");
                    break;

                case 3:
                    Console.Write("Enter ID to delete: ");
                    int delId = int.Parse(Console.ReadLine());
                    bool foundDelete = false;
                    for (int i = 0; i < count; i++)
                    {
                        if (employees[i].Id == delId)
                        {
                            for (int j = i; j < count - 1; j++)
                            {
                                employees[j] = employees[j + 1];
                            }
                            count--;
                            Console.WriteLine("Employee deleted.");
                            foundDelete = true;
                            break;
                        }
                    }
                    if (!foundDelete) Console.WriteLine("ID not found.");
                    break;

                case 4:
                    if (count == 0)
                    {
                        Console.WriteLine("No employees found.");
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"ID: {employees[i].Id}, Name: {employees[i].Name}, Age: {employees[i].Age}, Salary: {employees[i].Salary}, Email: {employees[i].Email}");
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static int ReadId()
    {
        int id;
        while (true)
        {
            Console.Write("Enter ID (number): ");
            if (int.TryParse(Console.ReadLine(), out id))
                break;
            Console.WriteLine("Invalid ID! Must be numbers only.");
        }
        return id;
    }

    static int ReadAge()
    {
        int age;
        while (true)
        {
            Console.Write("Enter Age (more than 21): ");
            if (int.TryParse(Console.ReadLine(), out age) && age > 21)
                break;
            Console.WriteLine("Invalid Age! Must be greater than 21.");
        }
        return age;
    }

    static double ReadSalary()
    {
        double salary;
        while (true)
        {
            Console.Write("Enter Salary (not negative): ");
            if (double.TryParse(Console.ReadLine(), out salary) && salary >= 0)
                break;
            Console.WriteLine("Invalid Salary! Cannot be negative.");
        }
        return salary;
    }

    static string ReadName()
    {
        string name;
        while (true)
        {
            Console.Write("Enter Name (no numbers): ");
            name = Console.ReadLine();
            bool hasNumber = false;
            foreach (char c in name)
            {
                if (char.IsDigit(c))
                {
                    hasNumber = true;
                    break;
                }
            }
            if (!hasNumber && name.Length > 0) break;
            Console.WriteLine("Invalid Name! Cannot contain numbers.");
        }
        return name;
    }

    static string ReadEmail()
    {
        string email;
        while (true)
        {
            Console.Write("Enter Email (must contain @gmail.com): ");
            email = Console.ReadLine();
            if (email.Contains("@gmail.com")) break;
            Console.WriteLine("Invalid Email! Must contain @gmail.com.");
        }
        return email;
    }
}
