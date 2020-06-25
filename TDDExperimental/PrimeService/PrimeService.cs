using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeService
{
    public class PrimeService
    {
        public bool IsPrimer(int candidate){
            if((candidate % 2 != 0 && candidate > 1) || candidate == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int SerieFibonacci(int numeroElementos)
        {
            var resultado = 0;
            if(numeroElementos == 0)
            {
                return resultado;
            }
            
            return resultado;
        }

        public int[] Divisors(int n)
        {
            if(n > 1)
            {
                List<int> divisors = new List<int>();
                int mitadNumero = (n / 2);
                for(int i = 2; i <= mitadNumero; i++)
                {
                    if(n%i == 0)
                    {
                        divisors.Add(i);
                    }
                }
                if (divisors.Count > 0) return divisors.ToArray();
                return null;
            }
            throw new Exception("No es mayor a 1");
        }

        public bool IsPalindrome(int x)
        {
            string number = x.ToString();
            int i=0, j=number.Length-1;
            for(int k=0; k < number.Length/2; k++)
            {
                if(number[i] != number[j])
                { 
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }

        public int squareRoot(int x)
        {
            
        }

        
    }
}
