﻿using CodeProblems.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeProblems
{
    public class SearchStruc
    {
        //Count how many negative numbers there are in a grid
        public static int CountNegatives(int[][] grid)
        {
            int negatives = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = grid[i].Length; j >= 0; j--)
                {
                    if (grid[i][j] < 0)
                    {
                        negatives++;
                    }
                }
            }
            return negatives;
        }

        //Aplica el algoritmo de la liebre y la tortuga
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
            while (tourtoise != hare)
            {
                tourtoise = nums[tourtoise];
                hare = nums[hare];          //bajas la velocidad de la liebre y se encuentran en el nodo duplicado
            }

            return hare;
        }

        public static int IslandPerimeter(int[][] grid)
        {
            int perimetro = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] != 1) break;
                    int izq = (j == 0) ? 0 : grid[i][j - 1];
                    int der = (j == grid[i].Length - 1) ? 0 : grid[i][j + 1];
                    int arriba = (i == 0) ? 0 : grid[i - 1][j];
                    int abajo = (i == grid.Length - 1) ? 0 : grid[i + 1][j];
                    perimetro += (4 - izq + der + arriba + abajo);
                }
            }
            return perimetro;
        }

        //Una ciudad tiene sus ciudades interconectadas,
        //si no tienen la misma cantidad de salidas y entradas,
        //entonces las carreteras no son buenas para la conexion
        public static bool newRoadSystem(bool[][] roadRegister)  //my approach
        {
            int row = 0,col=0;
            for(int i = 0; i < roadRegister.Length; i++)
            {
                for(int j=0; j < roadRegister[i].Length; j++)
                {
                    row += (roadRegister[i][j]) ? 1 : 0;
                    col += (roadRegister[j][i]) ? 1 : 0;
                }
                if (row != col) return false;
            }
            return true;
        }

    }
}