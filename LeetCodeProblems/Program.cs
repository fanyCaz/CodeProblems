using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace LeetCodeProblems
{
    class Program
    {

        /*Fuerza Bruta O(n^2) porque recorre el array dos veces, aunque le puse validacion que no todo*/
        public static int[] TwoSum(int[] nums, int target)
        {
            int j = 0;
            int veces = nums.Length;
            for(int i = 0; i < nums.Length - 1 ; i++)
            {
                veces -= 1;
                j = i + 1;
                for(int k = 0; k < veces; k++)
                {
                    if ((nums[i] + nums[j]) == target)
                    {
                        return new int[2] {i,j};
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
            Dictionary<int,int> mapa = new Dictionary<int,int>();
            for(int i = 0; i< nums.Length; i++)     /*agrega todos los valores a una tabla hash*/
            {
                mapa.Add(nums[i],i );       /*key,value*/
            }
            for(int i = 0; i < nums.Length; i++)
            {   
                int complement = target - nums[i];          /*busca el complemento del valor actual menos el target*/
                int value = 0;                              /*la salida del getValue es una variable separada*/
                mapa.TryGetValue(complement, out value);    
                if (mapa.ContainsKey(complement) && value != i ) /*pregunta si existe ese complemento y no es el numero actual*/
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
            for(int i = 0; i < nums.Length; i++)
            {
                mapa.Add(nums[i], i);
                int complement = target - nums[i];
                int value = 0;
                mapa.TryGetValue(complement, out value);
                if(mapa.ContainsKey(complement) && value != i)
                {
                    return new int[] { value, i };
                }
            }
            throw new Exception("No hubo solución");
        }

        public static void QuickFind()
        {
            Console.WriteLine("Leer cantidad de Numeros del Universo\n");
            string N = Console.ReadLine();
            var watch = System.Diagnostics.Stopwatch.StartNew();    //mide el tiempo de ejecucion
            UnionFind unionFind = new UnionFind(int.Parse(N));
            //El origen lo toma en donde esta el dll
            foreach (string line in File.ReadLines(@"../../../nodos.txt"))
            {
                int p = int.Parse(line[0].ToString());  //lo paso a string primero, porque estaba obteniendo los valores ASCII
                int q = int.Parse(line[2].ToString());
                if (!unionFind.Connected(p, q))
                {
                    unionFind.Union(p, q);
                    Console.WriteLine("P = {0}, Q = {1}", p, q);
                }
            }
            unionFind.Show();
            watch.Stop(); //fin de checar el tiempo de ejecucion
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void QuickUnionExec()
        {
            Console.WriteLine("Leer cantidad de Numeros del Universo\n");
            string N = Console.ReadLine();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            QuickUnionExec quickUnion = new QuickUnionExec(int.Parse(N));
            foreach (string line in File.ReadLines(@"../../../nodos.txt"))
            {
                int p = int.Parse(line[0].ToString());  //lo paso a string primero, porque estaba obteniendo los valores ASCII
                int q = int.Parse(line[2].ToString());
                if (!quickUnion.Connected(p, q))
                {
                    quickUnion.Union(p, q);
                    Console.WriteLine("P = {0}, Q = {1}", p, q);
                }
            }
            quickUnion.Show();
            watch.Stop(); //fin de checar el tiempo de ejecucion
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void QuickUnionWeigth()
        {
            Console.WriteLine("Leer cantidad de Numeros del Universo\n");
            string N = Console.ReadLine();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            QuickUnionWeighted quickUnion = new QuickUnionWeighted();
                               quickUnion.SetInicialSize(int.Parse(N));
            foreach (string line in File.ReadLines(@"../../../nodos.txt"))
            {
                int p = int.Parse(line[0].ToString());  //lo paso a string primero, porque estaba obteniendo los valores ASCII
                int q = int.Parse(line[2].ToString());
                if (!quickUnion.Connected(p, q))
                {
                    quickUnion.Union(p, q);
                    Console.WriteLine("P = {0}, Q = {1}", p, q);
                }
            }
            quickUnion.Show();
            watch.Stop(); //fin de checar el tiempo de ejecucion
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Dynamic Connectivity Client\n");
            QuickUnionWeigth();
            int[] response = MathProblems.RunningSum(new int[] { 3,1,2,10,1 });
            foreach(int i in response)
                Console.WriteLine("{0}",i);
        }
    }
}
