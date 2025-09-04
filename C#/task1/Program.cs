using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Check if a number is positive or negative");
            Console.WriteLine("2. Check if a number is even or odd");
            Console.WriteLine("3. Check if a rectangle is a square");

            Console.Write("Enter your choice (1-3): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Enter a number: ");
                double number = Convert.ToDouble(Console.ReadLine());

                if (number > 0)
                {
                    Console.WriteLine("The number is positive.");
                }
                else if (number < 0)
                {
                    Console.WriteLine("The number is negative.");
                }
                else
                {
                    Console.WriteLine("The number is zero.");
                }
            }
            else if (choice == 2)
            {
                Console.Write("Enter an integer: ");
                int number = Convert.ToInt32(Console.ReadLine());

                if (number % 2 == 0)
                {
                    Console.WriteLine("The number is even.");
                }
                else
                {
                    Console.WriteLine("The number is odd.");
                }
            }
            else if (choice == 3)
            {
                Console.Write("Enter the length: ");
                double length = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter the width: ");
                double width = Convert.ToDouble(Console.ReadLine());

                if (length == width)
                {
                    Console.WriteLine("It is a square.");
                }
                else
                {
                    Console.WriteLine("It is a rectangle.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }

}
