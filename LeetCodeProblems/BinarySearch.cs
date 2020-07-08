using System;
using System.Collections.Generic;
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
            Dictionary<int, int> neighbours = new Dictionary<int, int>();
            neighbours.Add(0, 4);
            neighbours.Add(1, 3);
            neighbours.Add(2, 2);
            neighbours.Add(3, 1);
            neighbours.Add(4, 0);

            for (int i = 0; i < grid.Length; i++)
            {
                for(int j = 0; j < grid[i].Length; j++)
                {
                    if(grid[i][4 % j+1] == 1)
                    {
                        return 1;
                    }
                }
            }
            throw new Exception("Error al ejecutar");
        }
    }
}
