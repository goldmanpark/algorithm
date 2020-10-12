using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution_1012
    {
        public static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            for(int i = 0 ; i < T ; i++)
            {
                string input = Console.ReadLine();
                string[] spl = input.Split(' ');
                int width = int.Parse(spl[0]);
                int height = int.Parse(spl[1]);
                int cabbage = int.Parse(spl[2]);
                List<Tuple<int, int>> cabList = new List<Tuple<int, int>>();
                for(int j = 0 ; j < cabbage ; j++)
                {
                    input = Console.ReadLine();
                    spl = input.Split(' ');
                    Tuple<int, int> temp = new Tuple<int, int>(int.Parse(spl[1]), int.Parse(spl[0]));   //get height, width point
                    cabList.Add(temp);
                }

                DFS dfs = new DFS(width, height, cabList);
                Console.WriteLine(dfs.startDFS());
            }
            
        }

        public class DFS
        {
            int width, height;
            int[,] map;
            bool[,] isVisited;
            List<Tuple<int, int>> cabbageList;

            public DFS(int w, int h, List<Tuple<int, int>> list)
            {
                this.width = w;
                this.height = h;
                this.map = new int[h,w];
                this.isVisited = new bool[h,w];
                this.cabbageList = list;
                foreach(var item in cabbageList)
                    map[item.Item1, item.Item2] = 1;
            }

            public int startDFS()
            {
                int answer = 0;
                foreach(var item in cabbageList){
                    if(!isVisited[item.Item1, item.Item2])
                    {
                        doDFS(item.Item1, item.Item2);
                        answer++;
                    }
                }
                return answer;
            }

            private void doDFS(int h, int w)
            {
                if(h < 0 || h >= height || w < 0 || w >= width)
                    return;
                if(isVisited[h, w] || map[h, w] == 0)
                    return;

                isVisited[h, w] = true;
                doDFS(h - 1, w);
                doDFS(h, w - 1);
                doDFS(h + 1, w);
                doDFS(h, w + 1);
            }
        }
    }    
}