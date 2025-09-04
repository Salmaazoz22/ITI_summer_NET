//ref program
//using System;

//class RefCalculator
//{
//    static void Calculate(double a, double b,
//                          ref double add, ref double sub,
//                          ref double mul, ref double div)
//    {
//        add = a + b;
//        sub = a - b;
//        mul = a * b;
//        div = (b != 0) ? a / b : double.NaN;
//    }

//    static void Main()
//    {
//        double a = 20, b = 5;
//        double add = 0, sub = 0, mul = 0, div = 0;
//        Calculate(a, b, ref add, ref sub, ref mul, ref div);

//        Console.WriteLine($"{a} + {b} = {add}");
//        Console.WriteLine($"{a} - {b} = {sub}");
//        Console.WriteLine($"{a} * {b} = {mul}");
//        Console.WriteLine($"{a} / {b} = {div}");
//    }
//}


//out program
//using System;

//class OutCalculator
//{
//    static void Calculate(double a, double b,
//                          out double add, out double sub,
//                          out double mul, out double div)
//    {
//        add = a + b;
//        sub = a - b;
//        mul = a * b;
//        div = (b != 0) ? a / b : double.NaN;
//    }

//    static void Main()
//    {
//        double a = 20, b = 5;
//        double add, sub, mul, div;
//        Calculate(a, b, out add, out sub, out mul, out div);

//        Console.WriteLine($"{a} + {b} = {add}");
//        Console.WriteLine($"{a} - {b} = {sub}");
//        Console.WriteLine($"{a} * {b} = {mul}");
//        Console.WriteLine($"{a} / {b} = {div}");
//    }
//}


//switch program
//using System;

//class SwitchCalculator
//{
//    static double Calculate(double a, double b, char op)
//    {
//        switch (op)
//        {
//            case '+': return a + b;
//            case '-': return a - b;
//            case '*': return a * b;
//            case '/': return (b != 0) ? a / b : double.NaN;
//            default:
//                Console.WriteLine("Invalid operator!");
//                return double.NaN;
//        }
//    }

//    static void Main()
//    {
//        double a = 20, b = 5;

//        Console.WriteLine($"{a} + {b} = {Calculate(a, b, '+')}");
//        Console.WriteLine($"{a} - {b} = {Calculate(a, b, '-')}");
//        Console.WriteLine($"{a} * {b} = {Calculate(a, b, '*')}");
//        Console.WriteLine($"{a} / {b} = {Calculate(a, b, '/')}");
//    }
//}



////Array program
//using System;

//class ArrayCalculator
//{
//    static double[] Calculate(double[] nums)
//    {
//        if (nums == null || nums.Length < 2)
//            throw new ArgumentException("Provide at least two numbers in the array: [a, b].");

//        double a = nums[0], b = nums[1];

//        double add = a + b;
//        double sub = a - b;
//        double mul = a * b;
//        double div = (b != 0) ? a / b : double.NaN;

//        return new double[] { add, sub, mul, div };
//    }

//    static void Main()
//    {
//        double[] input = { 20, 5 };
//        double[] result = Calculate(input);
//        Console.WriteLine($"Add: {result[0]}");
//        Console.WriteLine($"Sub: {result[1]}");
//        Console.WriteLine($"Mul: {result[2]}");
//        Console.WriteLine($"Div: {result[3]}");
//    }
//}

////object program
//using System;

//class ObjectCalculator
//{

//    static object Calculate(object aObj, object bObj)
//    {
//        double a = Convert.ToDouble(aObj);
//        double b = Convert.ToDouble(bObj);

//        double add = a + b;
//        double sub = a - b;
//        double mul = a * b;
//        double div = (b != 0) ? a / b : double.NaN;

//        return new object[] { add, sub, mul, div };
//    }

//    static void Main()
//    {
//        object a = 12, b = 3;

//        object resultObj = Calculate(a, b);

//        object[] results = (object[])resultObj;

//        Console.WriteLine($"{a} + {b} = {results[0]}");
//        Console.WriteLine($"{a} - {b} = {results[1]}");
//        Console.WriteLine($"{a} * {b} = {results[2]}");
//        Console.WriteLine($"{a} / {b} = {results[3]}");
//    }
//}

//tuble program
//using System;

//class TupleCalculator
//{

//    static Tuple<double, double, double, double> Calculate(double a, double b)
//    {
//        double add = a + b;
//        double sub = a - b;
//        double mul = a * b;
//        double div = (b != 0) ? a / b : double.NaN;

//        return Tuple.Create(add, sub, mul, div);
//    }

//    static void Main()
//    {
//        double a = 15, b = 5;

//        var results = Calculate(a, b);

//        Console.WriteLine($"{a} + {b} = {results.Item1}");
//        Console.WriteLine($"{a} - {b} = {results.Item2}");
//        Console.WriteLine($"{a} * {b} = {results.Item3}");
//        Console.WriteLine($"{a} / {b} = {results.Item4}");
//    }
//}

//static program
using System;

class StaticCalculator
{
    // Static fields to hold results
    public static double Add;
    public static double Sub;
    public static double Mul;
    public static double Div;

    public static void Calculate(double a, double b)
    {
        Add = a + b;
        Sub = a - b;
        Mul = a * b;
        Div = (b != 0) ? a / b : double.NaN;
    }

    static void Main()
    {
        double a = 12, b = 4;

      
      
        Calculate(a, b);

        Console.WriteLine($"{a} + {b} = {Add}");
        Console.WriteLine($"{a} - {b} = {Sub}");
        Console.WriteLine($"{a} * {b} = {Mul}");
        Console.WriteLine($"{a} / {b} = {Div}");
    }
}

