using System;
using System.Collections.Generic;

namespace CodeProblems
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(19));

            System.Linq.Expressions.Expression<Func<int, int>> e = x => x * x;
            
        }
    }
}
