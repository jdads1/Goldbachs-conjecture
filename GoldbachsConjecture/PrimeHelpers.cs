namespace GoldbachsConjecture
{
    class PrimeHelpers
    {
        public static bool IsPrime(int Number)
        {
            bool Result = true; // assume prime until found otherwise

            // start at 2 and search up to half of the number
            // this could probably be made more efficient by only searching with primes
            for (int i = 2; i <= (Number / 2); i++)
            {
                double DivResult = Number / (double)i;

                // if the result does not have any fractional value then it is not a prime
                if (DivResult - ((int)DivResult) == 0)
                {
                    // number is not prime
                    Result = false;
                    break;
                }
            }

            return Result;
        }

        public static int FindLargestPrime(int Max)
        {
            int Result = -1;

            // validate input
            if (Max > 0)
            {
                // start search for prime at max and work down
                for (int i = Max; i > 0; i--)
                {
                    if (IsPrime(i))
                    {
                        Result = i;
                        break;
                    }
                }
            }

            return Result;
        }

        public static int FindNextPrime(int Number)
        {
            int Result = -1;

            // validate input
            if (Number > 0)
            {
                // start search at the next number
                int currNumber = Number + 1;
                while( Result < 0 )
                {
                    if(IsPrime(currNumber))
                    {
                        Result = currNumber;
                    }
                    else
                    {
                        currNumber++;
                    }
                }
            }

            return Result;
        }
    }
}
