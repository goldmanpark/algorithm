using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution_11047
    {
        public static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            string [] tokens = inputLine.Split(' ');
            int N = int.Parse(tokens[0]);
            int K = int.Parse(tokens[1]);
            int answer = 0;
            int maxIdx = 0;
            List<int> list = new List<int>();

            for (int i = 0; i < N; i++)
            {
                int tmp = int.Parse(Console.ReadLine());
                list.Add(tmp);
                if(tmp <= K)
                    maxIdx = i;
            }

            int cnt = 0;
            while(K > 0){
                cnt = 0;
                if(K % list[maxIdx] == 0){
                    cnt = K / list[maxIdx];
                    K = 0;
                    answer += cnt;
                }
                else{
                    cnt = K / list[maxIdx];
                    K -= cnt * list[maxIdx];
                    answer += cnt;
                    maxIdx--;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
