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
        static List<int> idxHist;   //history of stepping on the stairs, storing steps(index of stairs).

        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            stairs = new int[N + 1];
            memo = new int[N + 1];
            idxHist = new List<int>();

            for(int i = 1 ; i <= N ; i++){
                stairs[i] = int.Parse(Console.ReadLine());
            }
            memo[1] = stairs[1];
            memo[2] = stairs[1] + stairs[2];
            idxHist.Add(0);

            Console.WriteLine(GetSolution(N));
            for(int i = 0 ; i <= N ; i++)
                Console.Write(memo[i].ToString() + " ");
            Console.WriteLine();
            idxHist.ForEach((x) => { Console.Write(x.ToString() + " "); });
        }

        private static int GetSolution(int n)
        {
            if(memo[n] != 0)
                return memo[n];
            else
            {
                int x = GetSolution(n - 1) + stairs[n];
                int y = GetSolution(n - 2) + stairs[n];

                if(idxHist.Count >= 2)
                {                    
                    int lastIdx1 = idxHist[idxHist.Count - 1];
                    int lastIdx2 = idxHist[idxHist.Count - 2];

                    if(lastIdx1 == lastIdx2 + 1){
                        if(n - 1 == lastIdx1 + 1){
                            memo[n] = x >= y ? x : y;
                        }
                        else{
                            memo[n] = x;
                            idxHist.Add(n - 1);
                        }
                    }
                    else{
                        if(x >= y){
                            memo[n] = x;
                            idxHist.Add(n - 1);
                        }
                        else{
                            memo[n] = y;
                            idxHist.Add(n - 2);
                        }
                    }
                }
                else{
                    if(x >= y){
                        memo[n] = x;
                        idxHist.Add(n - 1);
                    }
                    else{
                        memo[n] = y;
                        idxHist.Add(n - 2);
                    }
                }
                return memo[n];
            }
        }
    }
}