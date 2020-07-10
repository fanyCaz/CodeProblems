using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.XPath;

namespace LeetCodeProblems
{
    class BinarySearch
    {
        //Count how many negative numbers there are in a grid
        public static int CountNegatives(int[][] grid)
        {
            int negatives = 0;
            for(int i = 0; i< grid.Length; i++)
            {
                for(int j= grid[i].Length; j >= 0; j--)
                {
                    if(grid[i][j] < 0)
                    {
                        negatives++;
                    }
                }
            }
            return negatives;
        }

        public static int FindDuplicateNumber(int[] nums)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                if (numbers.ContainsKey(nums[i]))
                {
                    return nums[i];
                }
                numbers.Add(nums[i], 1);
                
            }
            throw new Exception("No existe ese numero");
        }

        public static int FindDuplicateNumberFloydAlg(int[] nums)
        {
            int tourtoise = nums[0];
            int hare = nums[0];

            do
            {
                tourtoise = nums[tourtoise];
                hare = nums[nums[hare]]; //va al doble de velocidad de la tortuga
            } while (tourtoise != hare);

            tourtoise = nums[0];
            while(tourtoise != hare)
            {
                tourtoise = nums[tourtoise];
                hare = nums[hare];
            }

            return hare;
        }

        public static int IslandPerimeter(int[][] grid)
        {
            int perimetro = 0;
            Console.WriteLine(grid);
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] != 1) break; 
                    int izq = (j == 0) ? 0 : grid[i][j-1];
                    int der = (j == grid[i].Length - 1) ? 0 : grid[i][j+1];
                    int arriba = (i == 0) ? 0 : grid[i-1][j];
                    int abajo  = (i == grid.Length - 1) ? 0 : grid[i+ 1][j];
                    perimetro += (4 - izq + der + arriba + abajo);
                    Console.WriteLine("{0},{1},{2},{3}",izq, der, arriba, abajo);
                }
            }
            return perimetro;
        }
    }
}
