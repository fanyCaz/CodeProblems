using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeProblems
{
    class MathProblems
    {
        /*Majority element is the one that appears more than n/2 times in a  n-length array*/
        public static int MajorityElement(int[] nums)
        {
            int timesAppeared = nums.Length/2;
            Dictionary<int, int> elements = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if ( elements.ContainsKey(nums[i]))
                {
                    elements.TryGetValue(nums[i], out int veces);
                    elements[nums[i]] = veces + 1;
                }
                else
                {
                    elements.Add(nums[i], 1);
                }
                elements.TryGetValue(nums[i], out int aux);
                if (aux > timesAppeared)
                {
                    return nums[i];
                }
            }
            throw new Exception("No habia ese valor");
        }

        public static int[] RunningSum(int[] nums)
        {
            if(nums.Length < 1 || nums.Length > 1000)
            {
                throw new Exception("No se puede esta cantidad");
            }
            int lastValue = nums.First();
            for (int i = 0; i < nums.Length ; i++)
            {
                nums[i] = lastValue;
                lastValue = lastValue + nums[(i+1) % nums.Length];
            }


            return nums;
        }

        public static int NumberOfSteps(int num)
        {
            int steps = 0;
            while(num != 0)
            {
                num = (num % 2 == 0) ? num / 2 : num - 1;
                steps += 1;
            }
            return steps;
        }

        public static int XorOperation(int n, int start)
        {
            //XOR Exclusive OR : 1 + 0 = 1, 1 + 1 = 0, 0 + 0 = 0;
            //En numeros suma sus numeros en binario
            //explanation: https://riptutorial.com/es/cplusplus/example/8514/----xor-bitwise--or-exclusivo-
            int resultXor = 0;
            for(int i= 0; i < n; i++)
            {
                resultXor ^= start + 2 * i;
            }
            return resultXor;
        }
    }
}
