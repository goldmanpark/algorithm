using System;
/*
    When Number of houses is N,
    then min(N) = min(N-1) + (minimum value of index N, satisfying the condition of N-1)

    if a color of house i is Red,
    then memo[i, R] = min(memo[i - 1, G], memo[i - 1, B]) + cost[i, R]
    It's necessary to calculate memo[i, R], memo[i, G], memo[i, B]
    because color costs of a specific index can be all same
*/
namespace Solution
{
    public class Solution_1149
    {
        static int[,] memo;
        static int[,] costList;

        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            memo = new int[N, 3];
            costList = new int[N, 3];

            for(int i = 0 ; i < N ; i++){
                string input = Console.ReadLine();
                string[] spl = input.Split(' ');
                costList[i, 0] = int.Parse(spl[0]);
                costList[i, 1] = int.Parse(spl[1]);
                costList[i, 2] = int.Parse(spl[2]);
            }

            memo[0, 0] = costList[0, 0];
            memo[0, 1] = costList[0, 1];
            memo[0, 2] = costList[0, 2];

            for(int i = 1 ; i <= N - 1 ; i++){
                memo[i, 0] = Math.Min(memo[i - 1, 1], memo[i - 1, 2]) + costList[i, 0];
                memo[i, 1] = Math.Min(memo[i - 1, 0], memo[i - 1, 2]) + costList[i, 1];
                memo[i, 2] = Math.Min(memo[i - 1, 0], memo[i - 1, 1]) + costList[i, 2];
            }
            
            Console.WriteLine(Math.Min(Math.Min(memo[N - 1, 0], memo[N - 1, 1]), memo[N - 1, 2]));
        }
    }
}