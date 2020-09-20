using System;

namespace Solution
{
    public class Solution_8958
    {
        public static void Main(string[] args)
        {
            int inputSize = int.Parse(Console.ReadLine());
            string [] strs = new string[inputSize];
            
            for(int i = 0 ; i < inputSize ; i++){
                strs[i] = Console.ReadLine();
            }

            for(int i = 0 ; i < inputSize ; i++){
                int answer = 0;
                int minAns = 0;
                for(int j = 0 ; j < strs[i].Length ; j++){
                    if (strs[i][j] == 'O')
                        answer += ++minAns;
                    else if (strs[i][j] == 'X')
                        minAns = 0;
                }
                Console.WriteLine(answer);
            }
        }
    }
}
