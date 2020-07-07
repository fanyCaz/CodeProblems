using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
