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

    // BONUS method 
    public virtual double CalculateBonus()
    {
        return Salary * 0.05; // 5% bonus for base employees
    }

    public virtual void Display()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Age: {Age}, Salary: {Salary}, Email: {Email}");
        Console.WriteLine($"Bonus: {CalculateBonus()}");
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

    public override double CalculateBonus()
    {
        return Salary * 0.10; // 10% bonus for HR
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Department: {Department}, Position: {Position}");
    }
}

class Developer : Employee
{
    private string programmingLanguage;
    private int yearsOfExperience;

    public string ProgrammingLanguage
    {
        get { return programmingLanguage; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value)) programmingLanguage = value;
            else throw new Exception("Invalid Programming Language! Cannot be empty.");
        }
    }

    public int YearsOfExperience
    {
        get { return yearsOfExperience; }
        set
        {
            if (value >= 0) yearsOfExperience = value;
            else throw new Exception("Invalid Experience! Cannot be negative.");
        }
    }

    public Developer(int id, string name, int age, double salary, string email, string programmingLanguage, int yearsOfExperience)
        : base(id, name, age, salary, email)
    {
        ProgrammingLanguage = programmingLanguage;
        YearsOfExperience = yearsOfExperience;
    }

    public override double CalculateBonus()
    {
        return Salary * 0.15; // 15% bonus for Developers
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Programming Language: {ProgrammingLanguage}, Years of Experience: {YearsOfExperience}");
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
        Console.Write("Enter max number of Developers: ");
        int devSize = int.Parse(Console.ReadLine());

        Employee[] employees = new Employee[empSize];
        HR[] hrs = new HR[hrSize];
        Developer[] developers = new Developer[devSize];

        int empCount = 0, hrCount = 0, devCount = 0;

        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1 - Employee Menu");
            Console.WriteLine("2 - HR Menu");
            Console.WriteLine("3 - Developer Menu");
            Console.WriteLine("0 - Exit");
            Console.Write("Choose: ");
            int mainChoice = int.Parse(Console.ReadLine());

            if (mainChoice == 0) break;

            if (mainChoice == 1) // Employee Menu
            {
                ManageMenu("Employee", employees, ref empCount, empSize);
            }
            else if (mainChoice == 2) // HR Menu
            {
                ManageMenu("HR", hrs, ref hrCount, hrSize);
            }
            else if (mainChoice == 3) // Developer Menu
            {
                ManageMenu("Developer", developers, ref devCount, devSize);
            }
        }
    }

    static void ManageMenu<T>(string title, T[] arr, ref int count, int maxSize) where T : Employee
    {
        while (true)
        {
            Console.WriteLine($"\n{title} Menu:");
            Console.WriteLine($"1 - Add {title}");
            Console.WriteLine($"2 - Edit {title} by ID");
            Console.WriteLine($"3 - Delete {title} by ID");
            Console.WriteLine($"4 - View All {title}s");
            Console.WriteLine("0 - Back to Main Menu");
            Console.Write("Choose: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 0) break;

            switch (choice)
            {
                case 1:
                    if (count >= maxSize) { Console.WriteLine($"{title} list is full."); break; }
                    try
                    {
                        arr[count] = (T)CreateObject(title);
                        count++;
                        Console.WriteLine($"{title} added.");
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    break;

                case 2:
                    Console.Write("Enter ID to edit: ");
                    int editId = int.Parse(Console.ReadLine());
                    bool foundEdit = false;
                    for (int i = 0; i < count; i++)
                    {
                        if (arr[i].Id == editId)
                        {
                            try
                            {
                                arr[i] = (T)CreateObject(title);
                                Console.WriteLine($"{title} updated.");
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
                    for (int i = 0; i < count; i++)
                    {
                        if (arr[i].Id == delId)
                        {
                            for (int j = i; j < count - 1; j++)
                                arr[j] = arr[j + 1];
                            count--;
                            Console.WriteLine($"{title} deleted.");
                            foundDelete = true;
                            break;
                        }
                    }
                    if (!foundDelete) Console.WriteLine("ID not found.");
                    break;

                case 4:
                    if (count == 0) Console.WriteLine($"No {title}s found.");
                    else for (int i = 0; i < count; i++) arr[i].Display();
                    break;
            }
        }
    }

    static Employee CreateObject(string type)
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

        if (type == "Employee")
        {
            return new Employee(id, name, age, salary, email);
        }
        else if (type == "HR")
        {
            Console.Write("Enter Department: ");
            string department = Console.ReadLine();
            Console.Write("Enter Position: ");
            string position = Console.ReadLine();
            return new HR(id, name, age, salary, email, department, position);
        }
        else // Developer
        {
            Console.Write("Enter Programming Language: ");
            string progLang = Console.ReadLine();
            Console.Write("Enter Years of Experience: ");
            int years = int.Parse(Console.ReadLine());
            return new Developer(id, name, age, salary, email, progLang, years);
        }
    }
}
