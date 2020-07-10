using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    class QuickUnionWeighted
    {
        private int[] id = new int[] { };
        private int[] sz = new int[] { };
        public void SetInicialSize(int N)
        {
            id = new int[N];
            sz = new int[N];
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
                sz[i] = 1;  //se le agrega el peso inicial a cada nodo
            }
        }

        private int Root(int node)
        {
            if (id[node] != node)     //##solucion con recursividad, tarda mas de 10 ms
            {
                id[node] = id[id[node]];        //comprimir el path del nodo a la raiz,
                                                //haciendo que cada uno apunte a la raiz
                return Root(id[node]);  //busca la raiz del valor en el arreglo hasta que sean iguales
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
            if( rootP == rootQ) { return; }
            if(sz[rootP] < sz[rootQ])
            {
                id[rootP] = rootQ;
                sz[rootQ] += sz[rootP];
            }
            else
            {
                id[rootQ] = rootP;
                sz[rootP] += sz[rootQ];
            }
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
