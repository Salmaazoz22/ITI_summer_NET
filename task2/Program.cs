////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;
//////program1

//namespace task2
//{
//    using System;

//    class Program
//    {
//        static void Main()
//        {
//            string input;
//            bool hasDigits;

//            do
//            {
//                Console.Write("Enter a string without digits: ");
//                input = Console.ReadLine();

//                hasDigits = false;
//                foreach (char c in input)
//                {
//                    if (c >= '0' && c <= '9')
//                    {
//                        hasDigits = true;
//                        Console.WriteLine("The string contains digits. Try again.");
//                        break;
//                    }
//                }

//            } while (hasDigits);

//            Console.WriteLine("Valid string entered: " + input);
//        }
//    }

//}


//////program2

//using System;

//class Program
//{
//    static void Main()
//    {
//        for (int i = 1; i <= 12; i++)
//        {
//            Console.WriteLine("Table of " + i);
//            for (int j = 1; j <= 12; j++)
//            {
//                Console.WriteLine(i + " x " + j + " = " + (i * j));
//            }
//            Console.WriteLine();
//        }
//    }
//}


////program3
//using System;

//class Program
//{
//    static void Main()
//    {
//        string id;
//        int age;
//        double salary;
//        string name;
//        string email;

//        // ID must be a number
//        while (true)
//        {
//            Console.Write("Enter ID (number): ");
//            id = Console.ReadLine();
//            bool isNumber = true;
//            foreach (char c in id)
//            {
//                if (c < '0' || c > '9')
//                {
//                    isNumber = false;
//                    break;
//                }
//            }
//            if (isNumber && id.Length > 0) break;
//            Console.WriteLine("Invalid ID! Must be numbers only.");
//        }

//        // Age must be more than 21
//        while (true)
//        {
//            Console.Write("Enter Age (more than 21): ");
//            if (int.TryParse(Console.ReadLine(), out age) && age > 21)
//                break;
//            Console.WriteLine("Invalid Age! Must be a number greater than 21.");
//        }

//        // Salary must not be negative
//        while (true)
//        {
//            Console.Write("Enter Salary (not negative): ");
//            if (double.TryParse(Console.ReadLine(), out salary) && salary >= 0)
//                break;
//            Console.WriteLine("Invalid Salary! Cannot be negative.");
//        }

//        // Name must not contain numbers
//        while (true)
//        {
//            Console.Write("Enter Name (no numbers): ");
//            name = Console.ReadLine();
//            bool hasNumber = false;
//            foreach (char c in name)
//            {
//                if (c >= '0' && c <= '9')
//                {
//                    hasNumber = true;
//                    break;
//                }
//            }
//            if (!hasNumber && name.Length > 0) break;
//            Console.WriteLine("Invalid Name! Cannot contain numbers.");
//        }

//        // Email must contain @gmail.com
//        while (true)
//        {
//            Console.Write("Enter Email (must contain @gmail.com): ");
//            email = Console.ReadLine();
//            if (email.Contains("@gmail.com")) break;
//            Console.WriteLine("Invalid Email! Must contain @gmail.com.");
//        }

//        Console.WriteLine("\n--- User Data ---");
//        Console.WriteLine("ID: " + id);
//        Console.WriteLine("Age: " + age);
//        Console.WriteLine("Salary: " + salary);
//        Console.WriteLine("Name: " + name);
//        Console.WriteLine("Email: " + email);
//    }
//}
