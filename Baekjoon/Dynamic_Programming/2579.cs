using System;
using System.Collections.Generic;
/*
    f(n) = max point on n-th stairs
    
    So,
    f(n) = max{f(n-1) + stairs[N], f(n-2) + stairs[N]}
    But,
    f(k) = f(k-1) + stairs[k]
    f(k-1) = f(k-2) + stairs[k-1]
    f(k-2) = f(k-3) + stairs[k-2]
    like this, 3-times continous process is banned.
*/
namespace Solution
{
    public class Solution_2579
    {
        static int[] stairs;
        static int[] memo;
        static ArrayList<int> idxHist;

        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            stairs = new int[N + 1];
            memo = new int[N + 1];

            for(int i = 1 ; i <= N ; i++){
                stairs[i] = int.Parse(Console.ReadLine());
            }
            memo[1] = stairs[1];

        }

        private static int GetSolution(int n)
        {
            if(memo[n] != 0)
                return memo[n];
            else{
                int x = GetSolution(n - 1) + stairs[n];
                int y = GetSolution(n - 2) + stairs[n];
                int i = idxHist.Count;
                if(i >= 2 && idxHist[i - 1] == idxHist[i - 2] + 1){
                    
                }
            }
        }
    }
}