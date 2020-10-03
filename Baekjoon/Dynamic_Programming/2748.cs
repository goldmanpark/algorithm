using System;

namespace Solution
{
    public class Solution_2748
    {
        static long[] arr;
        public static void Main(string[] args)
        {
            arr = new long[91];  //maximum input = 90
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(Fibonacci(input));
        }

        private static long Fibonacci(int x)
        {
            if(x == 1 || x == 2)
                return 1;
            if(arr[x] != 0)
                return arr[x];
            
            arr[x] = Fibonacci(x - 1) + Fibonacci(x - 2);
            return arr[x];
        }
    }    
}