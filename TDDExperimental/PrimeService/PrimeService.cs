using System;

namespace PrimeService
{
    public class PrimeService
    {
        public bool IsPrimer(int candidate){
            if(candidate % 2 != 0)
            {
                return true;
            }

            throw new NotImplementedException("No es Primo");
        }
    }
}
