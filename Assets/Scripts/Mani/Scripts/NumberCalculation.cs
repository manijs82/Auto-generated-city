using System;

namespace Mani.Scripts
{
    public static class NumberCalculation
    {
        public static bool IsEven(this int value) => value % 2 == 0;

        public static bool IsPrime(this int value)
        {
            for (int i = 2; i <= (int) Math.Sqrt(value); i++)
                if (value % i == 0)
                    return false;
            return true;
        }
    }
}
