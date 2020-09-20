using System;
using System.Collections.Generic;

namespace Solution_2606
{
    public class Solution_2606
    {
        static List<int> [] computers;
        static bool [] isVisited;

        static int answer = 0;

        public static void Main(string[] args)
        {
            int comCnt = int.Parse(Console.ReadLine());
            int edgeCnt = int.Parse(Console.ReadLine());
            computers = new List<int>[comCnt + 1];
            isVisited = new bool[comCnt + 1];

            for(int i = 0 ; i <= comCnt ; i++)
            {
                computers[i] = new List<int>();
            }

            for(int i = 0 ; i < edgeCnt ; i++)
            {
                string input = Console.ReadLine();
                string[] spl = input.Split(' ');
                int idx1 = int.Parse(spl[0]);
                int idx2 = int.Parse(spl[1]);

                computers[idx1].Add(idx2);
                computers[idx2].Add(idx1);
            }

            doDFS(1);
            Console.WriteLine(answer - 1);
        }

        public static void doDFS(int currentVertex)
        {
            isVisited[currentVertex] = true;
            answer++;

            foreach(int adjVertex in computers[currentVertex]){
                if(isVisited[adjVertex] == false)
                    doDFS(adjVertex);
            }
        }
    }
}