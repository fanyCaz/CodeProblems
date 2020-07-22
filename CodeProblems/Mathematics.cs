using System;
using System.Collections.Generic;
using System.Linq;

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

        //first duplicate with minimun index difference
        public static int firstDuplicate(int[] nums)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (numbers.ContainsKey(nums[i]))
                {
                    return nums[i];
                }
                numbers.Add(nums[i], 1);

            }
            return -1;
        }

        public static char firstNonDuplicateLetter(string s)
        {
            Dictionary<char, int> letras = new Dictionary<char, int>();
            List<char> unicas = new List<char>();
            foreach (char x in s)
            {
                if (letras.ContainsKey(x))
                {
                    unicas.Remove(x);
                }
                else
                {
                    letras.Add(x, 1);
                    unicas.Add(x);
                }
            }
            if (unicas.Count() > 0) return unicas.First();
            return '_';
        }

        public static char firstNonDuplicateLetterIndexes(string s)
        {
            //Si el index de esa letra al principio y al final es el mismo, quiere decir 
            // que la letra solo esta en una sola posicion en el array
            foreach (char x in s)
            {
                if (s.IndexOf(x) == s.LastIndexOf(x)) return x;
            }
            return '_';
        }

        public static int centuryFromYear(int year)
        {
            if (year < 100) return 1;
            if (year % 100 == 0)
            {
                return (year / 100);
            }
            return (year / 100) + 1;
        }

        public static bool checkPalindrome(string inputString)      //my approach
        {
            int j = inputString.Length - 1;
            for (int i = 0; i < inputString.Length / 2; i++)
            {
                if (inputString[i] != inputString[j])
                {
                    return false;
                }
                j--;
            }
            return true;
        }

        public static bool checkPalindromeBest(string inputString)
        {  //best approach
            return inputString.SequenceEqual(inputString.Reverse());
        }


        //the biggest product is returned
        public static int adjacentElementsProduct(int[] inputArray)
        {
            int result = -1001;
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                int mult = inputArray[i] * inputArray[i + 1];
                if (mult > result)
                {
                    result = mult;
                }
            }
            return result;
        }

        public static int adjacentElementsProductBest(int[] inputArray)
        {
            int result = -1001;
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                result = Math.Max(result, inputArray[i] * inputArray[i + 1]);
            }
            return result;
        }

        //El area agregada mas el area que ya tenia acumulada en la serie
        public static int shapeArea(int n)
        {
            return n * n + (n - 1) * (n - 1);
        }

        public static int makeArrayConsecutive2(int[] statues)
        {
            int statuesNeeded = 0;
            for (int i = statues.Min(); i < statues.Max(); i++)
            {
                if (!statues.Contains(i))
                {
                    statuesNeeded += 1;
                }
            }
            return statuesNeeded;
        }
        public static int makeArrayConsecutive(int[] statues)
        {
            return statues.Max() - statues.Min() - statues.Length + 1;
        }
    }
}
