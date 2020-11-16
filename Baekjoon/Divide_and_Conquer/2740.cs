using System;

namespace Solution
{
    public class Solution_2740
    {
        public static void Main(string[] args)
        {
            int [,] matrix1 = null;
            int [,] matrix2 = null;
            int [,] matrix3 = null;

            matrix1 = CreateMatrix();
            matrix2 = CreateMatrix();
            int row = matrix1.GetLength(0);
            int col = matrix2.GetLength(1);
            matrix3 = new int[row, col];

            for(int i = 0 ; i < row ; i++){
                for(int j = 0 ; j < col ; j++)
                    matrix3[i, j] = MultiplyWithIndex(i, j, matrix1, matrix2);
            }

            for(int i = 0 ; i < row ; i++){
                string outputStr = "";
                for(int j = 0 ; j < col ; j++)
                    outputStr += (matrix3[i, j].ToString() + " ");
                Console.WriteLine(outputStr.Substring(0, outputStr.Length - 1));
            }
        }

        private static int[,] CreateMatrix(){
            string input = Console.ReadLine();
            string[] spl = input.Split(' ');
            int row = Convert.ToInt32(spl[0]);
            int col = Convert.ToInt32(spl[1]);
            int [,] mat = new int[row, col];

            for(int i = 0 ; i < row ; i++){
                input = Console.ReadLine();
                spl = input.Split(' ');
                for(int j = 0 ; j < col ; j++)
                    mat[i, j] = Convert.ToInt32(spl[j]);
            }

            return mat;
        }

        private static int MultiplyWithIndex(int r, int c, int[,] mat1, int[,] mat2){
            int value = 0;
            for(int i = 0 ; i < mat1.GetLength(1) ; i++)
                value += (mat1[r, i] * mat2[i, c]);
            
            return value;
        }
    }
}
