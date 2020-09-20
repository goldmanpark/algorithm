using System;
using System.Collections.Generic;

namespace Solution
{
    public class DFSMap
    {
        int size;
        int [,] map;
        bool [,] isVisited;
        List<int> answer;

        public DFSMap()
        {
            this.size = int.Parse(Console.ReadLine());
            this.map = new int[size, size];
            this.isVisited = new bool[size, size];
            this.answer = new List<int>();

            for(int i = 0 ; i < size ; i++)
            {
                string tmp = Console.ReadLine();
                for(int j = 0 ; j < size ; j++)
                {
                    map[i,j] = int.Parse(tmp[j].ToString());
                }
            }
        }

        public void DoDFS()
        {
            for(int i = 0 ; i < size ; i++)
            {
                for(int j = 0 ; j < size ; j++)
                {
                    if(map[i,j] != 0 && isVisited[i,j] == false)
                    {
                        answer.Add(0);
                        DoDFS(i, j);
                    }
                }
            }
        }

        public void DoDFS(int i, int j)
        {
            if(i >= 0 && i < size && j >= 0 && j < size)
            {
                if(map[i,j] == 0 || isVisited[i,j] == true)
                return;
            
                map[i,j] = answer.Count + 1;
                isVisited[i,j] = true;
                answer[answer.Count - 1]++;

                DoDFS(i - 1, j);
                DoDFS(i, j - 1);
                DoDFS(i + 1, j);
                DoDFS(i, j + 1);
            }
        }

        public void PrintAnswer()
        {
            Console.WriteLine(answer.Count);
            answer.Sort();
            answer.ForEach((x) => {Console.WriteLine(x);});
        }
    }

    public class Solution_2667
    {
        public static void Main(string[] args)
        {
            DFSMap tmp = new DFSMap();
            tmp.DoDFS();
            tmp.PrintAnswer();
        }        
    }
}