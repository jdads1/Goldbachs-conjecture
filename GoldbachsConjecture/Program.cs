using System;

namespace GoldbachsConjecture
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("-------------------PRIME CALCULATOR--------------------");
            Console.WriteLine("-------------------------------------------------------");

            // loop until done
            while (!exit)
            {
                Console.WriteLine("Please input a numebr (type exit to quit):");
                string userInput = Console.ReadLine();

                // if the user types exit we are done
                if (userInput.ToLower() == "exit")
                {
                    exit = true;
                }
                else
                {
                    // attempt to convert the string to a number
                    if (int.TryParse(userInput, out int userNumber))
                    {
                        // check if the number is prime
                        bool isPrime = PrimeHelpers.IsPrime(userNumber);

                        if (isPrime)
                        {
                            Console.WriteLine(userNumber + " is a prime");
                        }
                        else
                        {
                            Console.WriteLine(userNumber + " is not a prime");
                            Console.WriteLine("Largest prime below " + userNumber + " is " + PrimeHelpers.FindLargestPrime(userNumber));
                        }

                        Console.WriteLine("Next prime is " + PrimeHelpers.FindNextPrime(userNumber));

                        if (!isPrime)
                        {
                            int primeFactorCount = 0;
                            int maxSearch = userNumber / 2;
                            for( int i = 2; i < maxSearch; i = PrimeHelpers.FindNextPrime(i))
                            {
                                int factor1 = i; // we know this is prime
                                double factor2 = userNumber / (double)factor1; // if this is prime we have found prime factors

                                if(factor2 - ((int)factor2) == 0 )
                                {
                                    // factor 2 is a whole number
                                    if(PrimeHelpers.IsPrime((int)factor2))
                                    {
                                        // factor 2 is a prime
                                        Console.WriteLine("Prime Factors: " + factor1 + "x" + factor2 + "=" + userNumber);

                                        primeFactorCount++;
                                    }
                                }
                            }

                            if(primeFactorCount == 0)
                            {
                                Console.WriteLine("No prime factors found");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Cannot have prime factors of a prime number");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Number");
                    }
                }
            }
        }
    }
}
