using System;

class Employee
{
    private int id;
    private string name;
    private int age;
    private double salary;
    private string email;

    public int Id
    {
        get { return id; }
        set
        {
            if (value > 0) id = value;
            else throw new Exception("Invalid ID! Must be numbers only.");
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            bool hasNumber = false;
            foreach (char c in value)
            {
                if (char.IsDigit(c)) { hasNumber = true; break; }
            }
            if (!hasNumber && value.Length > 0) name = value;
            else throw new Exception("Invalid Name! Cannot contain numbers.");
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value > 21) age = value;
            else throw new Exception("Invalid Age! Must be greater than 21.");
        }
    }

    public double Salary
    {
        get { return salary; }
        set
        {
            if (value >= 0) salary = value;
            else throw new Exception("Invalid Salary! Cannot be negative.");
        }
    }

    public string Email
    {
        get { return email; }
        set
        {
            if (value.Contains("@gmail.com")) email = value;
            else throw new Exception("Invalid Email! Must contain @gmail.com.");
        }
    }

    public Employee(int id, string name, int age, double salary, string email)
    {
        Id = id;
        Name = name;
        Age = age;
        Salary = salary;
        Email = email;
    }

    public virtual void Display()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Age: {Age}, Salary: {Salary}, Email: {Email}");
    }
}

class HR : Employee
{
    private string department;
    private string position;

    public string Department
    {
        get { return department; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value)) department = value;
            else throw new Exception("Invalid Department! Cannot be empty.");
        }
    }

    public string Position
    {
        get { return position; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value)) position = value;
            else throw new Exception("Invalid Position! Cannot be empty.");
        }
    }

    public HR(int id, string name, int age, double salary, string email, string department, string position)
        : base(id, name, age, salary, email)
    {
        Department = department;
        Position = position;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Department: {Department}, Position: {Position}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter max number of employees: ");
        int empSize = int.Parse(Console.ReadLine());
        Console.Write("Enter max number of HRs: ");
        int hrSize = int.Parse(Console.ReadLine());

        Employee[] employees = new Employee[empSize];
        HR[] hrs = new HR[hrSize];
        int empCount = 0, hrCount = 0;

        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1 - Employee Menu");
            Console.WriteLine("2 - HR Menu");
            Console.WriteLine("0 - Exit");
            Console.Write("Choose: ");
            int mainChoice = int.Parse(Console.ReadLine());

            if (mainChoice == 0) break;

            if (mainChoice == 1) // Employee Menu
            {
                while (true)
                {
                    Console.WriteLine("\nEmployee Menu:");
                    Console.WriteLine("1 - Add Employee");
                    Console.WriteLine("2 - Edit Employee by ID");
                    Console.WriteLine("3 - Delete Employee by ID");
                    Console.WriteLine("4 - View All Employees");
                    Console.WriteLine("0 - Back to Main Menu");
                    Console.Write("Choose: ");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 0) break;

                    switch (choice)
                    {
                        case 1:
                            if (empCount >= empSize) { Console.WriteLine("Employee list is full."); break; }
                            try
                            {
                                employees[empCount] = CreateEmployee();
                                empCount++;
                                Console.WriteLine("Employee added.");
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;

                        case 2:
                            Console.Write("Enter ID to edit: ");
                            int editId = int.Parse(Console.ReadLine());
                            bool foundEdit = false;
                            for (int i = 0; i < empCount; i++)
                            {
                                if (employees[i].Id == editId)
                                {
                                    try
                                    {
                                        employees[i] = CreateEmployee();
                                        Console.WriteLine("Employee updated.");
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
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
                            for (int i = 0; i < empCount; i++)
                            {
                                if (employees[i].Id == delId)
                                {
                                    for (int j = i; j < empCount - 1; j++)
                                        employees[j] = employees[j + 1];
                                    empCount--;
                                    Console.WriteLine("Employee deleted.");
                                    foundDelete = true;
                                    break;
                                }
                            }
                            if (!foundDelete) Console.WriteLine("ID not found.");
                            break;

                        case 4:
                            if (empCount == 0) Console.WriteLine("No employees found.");
                            else for (int i = 0; i < empCount; i++) employees[i].Display();
                            break;
                    }
                }
            }
            else if (mainChoice == 2) // HR Menu
            {
                while (true)
                {
                    Console.WriteLine("\nHR Menu:");
                    Console.WriteLine("1 - Add HR");
                    Console.WriteLine("2 - Edit HR by ID");
                    Console.WriteLine("3 - Delete HR by ID");
                    Console.WriteLine("4 - View All HRs");
                    Console.WriteLine("0 - Back to Main Menu");
                    Console.Write("Choose: ");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 0) break;

                    switch (choice)
                    {
                        case 1:
                            if (hrCount >= hrSize) { Console.WriteLine("HR list is full."); break; }
                            try
                            {
                                hrs[hrCount] = CreateHR();
                                hrCount++;
                                Console.WriteLine("HR added.");
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;

                        case 2:
                            Console.Write("Enter ID to edit: ");
                            int editId = int.Parse(Console.ReadLine());
                            bool foundEdit = false;
                            for (int i = 0; i < hrCount; i++)
                            {
                                if (hrs[i].Id == editId)
                                {
                                    try
                                    {
                                        hrs[i] = CreateHR();
                                        Console.WriteLine("HR updated.");
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
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
                            for (int i = 0; i < hrCount; i++)
                            {
                                if (hrs[i].Id == delId)
                                {
                                    for (int j = i; j < hrCount - 1; j++)
                                        hrs[j] = hrs[j + 1];
                                    hrCount--;
                                    Console.WriteLine("HR deleted.");
                                    foundDelete = true;
                                    break;
                                }
                            }
                            if (!foundDelete) Console.WriteLine("ID not found.");
                            break;

                        case 4:
                            if (hrCount == 0) Console.WriteLine("No HRs found.");
                            else for (int i = 0; i < hrCount; i++) hrs[i].Display();
                            break;
                    }
                }
            }
        }
    }

    static Employee CreateEmployee()
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Enter Salary: ");
        double salary = double.Parse(Console.ReadLine());
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();
        return new Employee(id, name, age, salary, email);
    }

    static HR CreateHR()
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Enter Salary: ");
        double salary = double.Parse(Console.ReadLine());
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();
        Console.Write("Enter Department: ");
        string department = Console.ReadLine();
        Console.Write("Enter Position: ");
        string position = Console.ReadLine();
        return new HR(id, name, age, salary, email, department, position);
    }
}
