using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution
{
    public class Solution_2573
    {
        public static void Main(string[] args)
        {
            DFS_Iceberg dfs = new DFS_Iceberg();
            dfs.GetAnswer();
        }

        public class DFS_Iceberg
        {
            int H, W, answer;   //Height, Width
            int [,] map;
            bool[,] isVisit;
            HashSet<Tuple<int,int>> iceSet;

            public DFS_Iceberg()
            {
                string input = Console.ReadLine();
                string[] spl = input.Split(' ');
                this.H = int.Parse(spl[0]);
                this.W = int.Parse(spl[1]);
                this.answer = 0;
                this.map = new int[H,W];
                this.iceSet = new HashSet<Tuple<int,int>>();

                for(int i = 0 ; i < H ; i++){
                    input = Console.ReadLine();
                    spl = input.Split(' ');
                    for(int j = 0 ; j < W ; j++){
                        map[i,j] = int.Parse(spl[j]);
                        if(map[i,j] > 0)
                            iceSet.Add(new Tuple<int,int>(i, j));
                    }
                }
            }

            public void GetAnswer()
            {
                bool isDivided = CheckDivide();
                if(isDivided)
                    answer = 0;
                else{
                    while(iceSet.Count > 0){
                        Melt();
                        if(iceSet.Count == 0 && !isDivided){    //All melt before divided
                            answer = 0;
                            break;
                        }            
                        isDivided = CheckDivide();
                        if(isDivided)
                            break;
                    }
                }                

                Console.WriteLine(answer);
            }

            public void Melt()
            {
                List<Tuple<int,int>> delList = new List<Tuple<int, int>>();
                answer++;

                foreach(var item in iceSet)
                {
                    int x = item.Item1;
                    int y = item.Item2;
                    if(x > 0 && map[x - 1, y] == 0 && !iceSet.Contains(new Tuple<int, int>(x - 1, y)) && map[x, y] > 0)
                        map[x,y]--;
                    if(x < H - 1 && map[x + 1, y] == 0 && !iceSet.Contains(new Tuple<int, int>(x + 1, y)) && map[x, y] > 0)
                        map[x,y]--;
                    if(y > 0 && map[x, y - 1] == 0 && !iceSet.Contains(new Tuple<int, int>(x, y - 1)) && map[x, y] > 0)
                        map[x,y]--;
                    if(y < W - 1 && map[x, y + 1] == 0 && !iceSet.Contains(new Tuple<int, int>(x, y + 1)) && map[x, y] > 0)
                        map[x,y]--;
                    if(map[x,y] == 0)
                        delList.Add(item);
                }

                foreach(var item in delList){
                    iceSet.Remove(item);
                }
            }

            public bool CheckDivide(){
                var start = iceSet.First();
                int xPos = start.Item1;
                int yPos = start.Item2;
                this.isVisit = new bool[H,W];

                if(iceSet.Count == CountDFS(xPos, yPos))
                    return false;
                else
                    return true;    //Divided
            }

            public int CountDFS(int x, int y)
            {
                if(x < 0 || y < 0 || x >= H || y >= W)
					return 0;
                if(isVisit[x,y] == true || map[x,y] == 0)
                    return 0;
                
                int cnt = 1;
                isVisit[x,y] = true;

                cnt += CountDFS(x - 1, y);
                cnt += CountDFS(x + 1, y);
                cnt += CountDFS(x, y - 1);
                cnt += CountDFS(x, y + 1);

                return cnt;
            }
        }
    }
}
