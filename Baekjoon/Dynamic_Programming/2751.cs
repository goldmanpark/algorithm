using System;
/*
    Modular Operation
    (a+b) mod m = ((a mod m) + (b mod m)) mod m
    
    Application of Fibonacci Sequence
    N   binary Sequence.
    1.  1
    2.  11, 00
    3.  100(1+00),              from 1.
        111(11+1), 001(00+1)    from 2.
    4.  1100(11+00), 0000(00+00),               from 2.
        1111(111+1), 0011(001+1), 1001(100+1)   from 3.

    So, F(n) mod m = {(F(n-1) mod m) + (F(N-2) mod m)} mod m
*/
namespace Solution
{
    public class Solution_2751
    {
        public static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int[] memo = new int[input + 1];
            for(int i = 0 ; i <= input ; i++)
                memo[i] = -1;

            Console.WriteLine(GetCountSequence(input, memo));
        }

        private static int GetCountSequence(int size, int[] memo)
        {
            if(size == 1)
                return 1;
            if(size == 2)
                return 2;
            else if(memo[size] != -1)
                return memo[size];
            else if(memo[size] == -1){
                memo[size] = (GetCountSequence(size - 1, memo) + GetCountSequence(size - 2, memo)) % 15746;
                return memo[size];
            }
            else
                return 0;
        }
    }
}
