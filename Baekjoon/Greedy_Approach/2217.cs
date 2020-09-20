using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution_2217
    {
        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int answer = 0;
            List<int> ropeList = new List<int>();

            for (int i = 0; i < N; i++)
            {
                ropeList.Add(int.Parse(Console.ReadLine()));
            }
            ropeList.Sort();

            for (int i = 1 ; i <= N ; i++) //i = count of rope
            {
                int x = i * ropeList[N - i];
                if(answer < x)
                    answer = x;
            }

            Console.WriteLine(answer);
        }
    }
}
