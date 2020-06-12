using System;

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
            else
            {

            }
            return resultado;
        }
    }
}
