using System;

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
                int[,] cabList = new int[cabbage,2];
                for(int j = 0 ; j < cabbage ; j++)
                {
                    input = Console.ReadLine();
                    spl = input.Split(' ');
                    cabList[j][0] = int.Parse(spl[0]);
                    cabList[j][1] = int.Parse(spl[1]);
                }

                DFS dfs = new DFS(width, height, cabbage, cabList);
            }
            
        }

        public class DFS
        {
            int width, height, cabbage;
            int[,] map;
            bool[,] isVisited;
            int[,] cabbageList;

            public DFS(int w, int h, int c, int[,] list)
            {
                this.width = w;
                this.height = h;
                this.cabbage = c;
                this.map = new int[h,w];
                this.isVisited = new bool[h,w];
                this.cabbageList = list;
            }

            public doDFS()
            {
                
            }
        }
    }    
}