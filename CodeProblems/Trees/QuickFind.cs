using System;
using System.Collections.Generic;
using System.Text;

namespace CodeProblems.Trees
{
    class QuickFind
    {
        private int[] id = new int[] { };

        public QuickFind(int N)
        {
            id = new int[N];
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
            }
        }

        public void Union(int p, int q)
        {
            //agregar una coneccion entre p y q
            int pValue = id[p];
            int qValue = id[q];
            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == pValue)
                {
                    id[i] = qValue;
                }
            }
        }

        public bool Connected(int p, int q)
        {
            //estan p y q dentro del mismo componente?
            return id[p] == id[q];
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
