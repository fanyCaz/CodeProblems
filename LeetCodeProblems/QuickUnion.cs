using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    //Algorithm --> QUICK UNION
    //Data Structure --> array[n]
    class QuickUnionExec
    {
        private int[] id = new int[] { };
        public QuickUnionExec(int N)
        {
            id = new int[N];
            for(int i = 0; i< N; i++)
            {
                id[i] = i;
            }
        }

        private int Root(int node)
        {
            //if (id[node] != node)
            //    Root(id[node]);
            //return id[node];
            while(node != id[node])
            {
                node = id[node];
            }
            return node;
        }

        public bool Connected(int p, int q)
        {
            return Root(p) == Root(q);
        }

        public void Union(int p, int q)
        {
            var rootQ = Root(q);
            var rootP = Root(p);
            id[rootP] = rootQ;
        }

        public void Show()
        {
            foreach (int i in id)
            {
                Console.WriteLine("{0}", i);
            }
        }

    }
}
