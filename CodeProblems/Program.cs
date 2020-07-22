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
            int[][] vs = new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 0 } };
            SearchStruc.BuildingRoads(4, vs);
        }
    }
}
