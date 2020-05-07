using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    class RetoMayo
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
    }
}
