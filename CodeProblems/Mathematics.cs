using System;
using System.Collections.Generic;

namespace CodeProblems
{
    public class Mathematics
    {
        /*Fuerza Bruta O(n^2) porque recorre el array dos veces, aunque le puse validacion que no todo*/
        public static int[] TwoSum(int[] nums, int target)
        {
            int j = 0;
            int veces = nums.Length;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                veces -= 1;
                j = i + 1;
                for (int k = 0; k < veces; k++)
                {
                    if ((nums[i] + nums[j]) == target)
                    {
                        return new int[2] { i, j };
                    }
                    j++;
                }
            }
            throw new Exception("No hubo solución");
        }

        /*Two Pass Hash Table trade space for speed*/
        public static int[] TwoSumHasTable(int[] nums, int target)
        {
            /*use a dictionary as a map of keys to values. Map Collection is a hash table*/
            Dictionary<int, int> mapa = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)     /*agrega todos los valores a una tabla hash*/
            {
                mapa.Add(nums[i], i);       /*key,value*/
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];          /*busca el complemento del valor actual menos el target*/
                int value = 0;                              /*la salida del getValue es una variable separada*/
                mapa.TryGetValue(complement, out value);
                if (mapa.ContainsKey(complement) && value != i) /*pregunta si existe ese complemento y no es el numero actual*/
                {
                    return new int[] { i, value };      /*retornas yeii*/
                }
            }
            throw new Exception("No hubo solución");
        }

        /*lo de arriba pero mejorado biiiish*/
        public static int[] TwoSumOnePassHashTable(int[] nums, int target)
        {
            Dictionary<int, int> mapa = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                mapa.Add(nums[i], i);
                int complement = target - nums[i];
                int value = 0;
                mapa.TryGetValue(complement, out value);
                if (mapa.ContainsKey(complement) && value != i)
                {
                    return new int[] { value, i };
                }
            }
            throw new Exception("No hubo solución");
        }
    }
}
