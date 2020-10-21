using System;

namespace Solution
{
    public class Solution_1932
    {
        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[,] triangle = new int[N, N];
            int[,] memo = new int[N, N];

            for(int i = 0 ; i < N ; i++){
                string input = Console.ReadLine();
                string[] spl = input.Split(' ');
                for(int j = 0 ; j <= i ; j++){
                    triangle[i, j] = int.Parse(spl[j]);
                }
            }
            memo[0, 0] = triangle[0, 0];

            for(int i = 1 ; i < N ; i++){   //floor 1 ~ N-1
                memo[i, 0] = memo[i - 1, 0] + triangle[i, 0];       //leftmost item of triangle floor
                memo[i, i] = memo[i - 1, i - 1] + triangle[i, i];   //rightmost item of triangle floor
                for(int j = 1 ; j < i ; j++){
                    if(memo[i - 1, j - 1] > memo[i - 1, j])
                        memo[i, j] = memo[i - 1, j - 1] + triangle[i, j];
                    else
                        memo[i, j] = memo[i - 1, j] + triangle[i, j];
                }
            }

            //get maxvalue from memo[N-1,]
            int maxVal = 0;
            for(int i = 0 ; i < N ; i++){
                if(memo[N - 1, i] > maxVal)
                    maxVal = memo[N - 1, i];
            }
            Console.WriteLine(maxVal);
        }
    }
}