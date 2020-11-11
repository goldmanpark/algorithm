using System;
using System.Collections.Generic;
/*
    2020.11.11 Not Complete : IndexOutOfRangeException

    f(n) = max point on n-th stairs, but 3-times continous process is banned.
    
    So,
    if stairs[n-2] is not visited
        f(n) = stairs[N] + max{f(n-1), f(n-2)} 
    else
        f(n) = stairs[N] + f(n-2)
*/
namespace Solution
{
    public class Solution_2579
    {
        static int[] stairs;
        static int[] memo;
        static bool[] visited;

        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            stairs = new int[N + 1];
            memo = new int[N + 1];
            visited = new bool[N + 1];

            for(int i = 1 ; i <= N ; i++){
                stairs[i] = int.Parse(Console.ReadLine());
            }
            memo[1] = stairs[1];
            
            Console.WriteLine(GetSolution(N));
            // for(int i = 0 ; i <= N ; i++)
            //     Console.Write(memo[i].ToString() + " ");
            // Console.WriteLine();
            // idxHist.ForEach((x) => { Console.Write(x.ToString() + " "); });
        }

        private static int GetSolution(int n)
        {
            if(memo[n] != 0)
                return memo[n];
            else{
                if(visited[n - 2]){
                    visited[n - 1] = true;
                    memo[n] = stairs[n] + GetSolution(n - 1);
                }
                else{
                    int idx = GetSolution(n - 1) > GetSolution(n - 2) ? (n - 1) : (n - 2);
                    visited[idx] = true;
                    memo[n] = stairs[n] + memo[idx];
                }
                return memo[n];
            }
        }
    }
}