using System;
/*
    When Number of houses is N,
    then min(N) = min(N-1) + (minimum value of index N, satisfying the condition of N-1)

    반례
    3
    1 1 1
    1 2 3
    3 2 1
    정답: 3
    답: 4
*/
namespace Solution
{
    public class Solution_1149
    {
        static int[] minArr;
        static char[] colors;
        static int[,] costList;

        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            minArr = new int[N];
            colors = new char[N];
            costList = new int[N,3];

            for(int i = 0 ; i < N ; i++){
                string input = Console.ReadLine();
                string[] spl = input.Split(' ');
                costList[i, 0] = Convert.ToInt32(spl[0]);
                costList[i, 1] = Convert.ToInt32(spl[1]);
                costList[i, 2] = Convert.ToInt32(spl[2]);
            }

            // initial setting for index of 0
            if(costList[0, 0] > costList[0, 1])
            {
                if(costList[0, 1] > costList[0, 2]){
                    colors[0] = 'B';
                    minArr[0] = costList[0, 2];
                }                        
                else{
                    colors[0] = 'G';
                    minArr[0] = costList[0, 1];
                }
            }
            else
            {
                if(costList[0, 0] > costList[0, 2]){
                    colors[0] = 'B';
                    minArr[0] = costList[0, 2];
                }                        
                else{
                    colors[0] = 'R';
                    minArr[0] = costList[0, 0];
                }
            }

            Console.WriteLine(GetSolution(N-1));
            for(int i = 0 ; i < N ; i++)
                Console.Write(colors[i].ToString() + " ");
        }

        private static int GetSolution(int idx)
        {
            if(minArr[idx] != 0)
                return minArr[idx];
            else
            {
                minArr[idx] = GetSolution(idx - 1);
                if(colors[idx - 1] == 'R')
                    minArr[idx] += GetMinimum(idx, 1, 2);
                else if(colors[idx - 1] == 'G')
                    minArr[idx] += GetMinimum(idx, 0, 2);
                else if(colors[idx - 1] == 'B')
                    minArr[idx] += GetMinimum(idx, 0, 1);
                
                return minArr[idx];
            }
        }

        private static int GetMinimum(int idx, int x, int y)
        {
            if(costList[idx, x] > costList[idx, y])
            {
                if(y == 0)
                    colors[idx] = 'R';
                else if(y == 1)
                    colors[idx] = 'G';
                else if(y == 2)
                    colors[idx] = 'B';
                return costList[idx, y];
            }
            else if(costList[idx, x] < costList[idx, y])
            {
                if(x == 0)
                    colors[idx] = 'R';
                else if(x == 1)
                    colors[idx] = 'G';
                else if(x == 2)
                    colors[idx] = 'B';
                return costList[idx, x];
            }
        }
    }
}