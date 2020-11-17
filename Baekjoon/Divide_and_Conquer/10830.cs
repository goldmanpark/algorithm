using System;
using System.Linq;

namespace Solution
{
    public class Solution_10830
    {
        static int N;

        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] spl = input.Split(' ');
            N = Convert.ToInt32(spl[0]);
            ulong K = Convert.ToUInt64(spl[1]);
            int [,] matrix = new int[N, N];

            for(int i = 0 ; i < N ; i++){
                input = Console.ReadLine();
                spl = input.Split(' ');
                for(int j = 0 ; j < N ; j++)
                    matrix[i, j] = Convert.ToInt32(spl[j]) % 1000;
                    // x mod x = 0, 0 mod x = 0
                    // maximum input number is 1000, so turn it to be 0
            }

            int [,] answer = GetSolution(K, matrix);
            for(int i = 0 ; i < N ; i++){
                for(int j = 0 ; j < N ; j++)
                    Console.Write(answer[i, j] + " ");
                Console.WriteLine();
            }
        }

        private static int[,] MultiplyMatrices(int[,] mat1, int[,] mat2)
        {
            int[,] result = new int [N, N];
            for(int i = 0 ; i < N ; i++){
                for(int j = 0 ; j < N ; j++){
                    int value = 0;
                    for(int k = 0 ; k < N ; k++){
                        value += (mat1[i, k] * mat2[k, j]);
                        value %= 1000;
                        // (a + B + c) mod m = 
                        // ((a + B) mod m + (c mod m)) mod m
                        // (((a mod m) + (b mod m) mod m) + (c mod m)) mod m
                    }
                    result[i, j] = value;
                }
            }
            
            return result;
        }

        private static int[,] GetSolution(ulong idx, int[,] matrix)
        {
            if(idx == 1)
                return matrix;
            else if(idx % 2 == 0){
                var mat = GetSolution(idx / 2, matrix);
                return MultiplyMatrices(mat, mat);
            }
            else
                return MultiplyMatrices(GetSolution(1, matrix), GetSolution(idx - 1, matrix));
        }
    }
}
