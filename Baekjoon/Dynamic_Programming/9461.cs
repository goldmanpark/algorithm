using System;
/*
    Padovan Sequence
    P(1) ~ P(5) = fixed
    when n >= 6
    P(n) = P(n-5) + P(n-1)
*/
namespace Solution
{
    public class Solution_9461
    {
        public static void Main(string[] args)
        {
            uint input = Convert.ToUInt32(Console.ReadLine());
            for(uint i = 0 ; i < input ; i++)
            {
                int testNum = int.Parse(Console.ReadLine());
                ulong[] memo = new ulong[101];  // maximum testNum = 100

                //tabulation
                memo[1] = 1;
                memo[2] = 1;
                memo[3] = 1;
                memo[4] = 2;
                memo[5] = 2;
                memo[6] = 3;
                memo[7] = 4;
                memo[8] = 5;
                memo[9] = 7;
                memo[10] = 9;

                Console.WriteLine(Padovan(testNum, memo));
            }            
        }

        private static ulong Padovan(int x, ulong[] memo)
        {
            if(x >= 6){
                if(memo[x] == 0)
                    memo[x] = Padovan(x - 1, memo) + Padovan(x - 5, memo);                    
                return memo[x];
            }
            else
                return memo[x];
        }
    }    
}