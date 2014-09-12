using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler9
{
    /// <summary>
    /// a: 200
    /// b: 375
    /// c: 425
    /// product: 31875000
    /// </summary>
    class Program
    {
        static int testedCombination = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("BruteForceSolution() : {0}", BruteForceSolution()); // 164079 tests | 83143 tests after 1 mod
            Console.WriteLine("BinarySearchSolution() : {0}", BinarySearchSolution()); // 4129 tests

            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
        }

        private static int BinarySearchSolution()
        {
            for (int c = 998; c > 334; c--)
            {

                int maxB = 1000 - c;
                int minB = maxB / 2;

                int b = FindTheRightB(c, minB, maxB);

                if (b != -1)
                {
                    int a = 1000 - b - c;
                    if (a != 0)
                    {
                        return a * b * c;
                    }
                }

            }

            return -1;
        }

        /* Do a recursive 
         * binary search on all the 
         * remaining possibilities*/
        private static int FindTheRightB(int c, int minB, int maxB)
        {
            int b = (minB + maxB) / 2;
            int a = 1000 - c - b;

            testedCombination++;
            if ((a * a) + (b * b) == (c * c))
            {
                return b;
            }
            else if (minB >= maxB)
            {
                return -1;
            }
            else if ((a * a) + (b * b) > (c * c))
            {
                return FindTheRightB(c, minB, b - 1);
            }
            else
            {
                return FindTheRightB(c, b + 1, maxB);
            }


        }

        /// <summary>
        /// Go through all of the possible combinations until
        /// the right one is found.
        /// </summary>
        /// <returns></returns>
        private static int BruteForceSolution()
        {
            for (int c = 998; c > 334; c--)
            {
                int a = 0;
                for (int b = 1000 - c; b > a; b--)
                {
                    a = 1000 - c - b;

                    //testedCombination++;
                    if (IsPythagoreanTriplet(a, b, c))
                    {
                        if (a != 0)
                        {
                            return a * b * c;
                        }
                    }
                }
            }

            return -1;
        }

        private static bool IsPythagoreanTriplet(int a, int b, int c)
        {
            if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2))
            {
                return true;
            }

            return false;
        }

    }
}
