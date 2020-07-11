using System;
using System.Collections.Generic;
using System.Text;

namespace CodeProblems.Trees
{
    class QuickUnion
    {
        private int[] id = new int[] { };
        public QuickUnion(int N)
        {
            id = new int[N];
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
            }
        }

        private int Root(int node)
        {
            if (id[node] != node)     //##solucion con recursividad, tarda mas de 10 ms
            {
                return Root(id[node]);  //busca la raiz del valor en el arreglo hasta que sean iguales
            }
            return node;

            //while (node != id[node])        //Solucion con While, tarda menos en promedio
            //{
            //    node = id[node];
            //}
            //return node;
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
