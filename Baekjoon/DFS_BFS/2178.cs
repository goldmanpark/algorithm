using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution_2178
    {
        private class BFS
        {
            int N, M;
            int [,] maze;
            bool[,] isVisited;

            Queue<int[]> queue;

            public BFS()
            {
                string input = Console.ReadLine();
                string [] spl = input.Split(' ');
                this.N = int.Parse(spl[0]);
                this.M = int.Parse(spl[1]);
                this.maze = new int[N,M];
                this.isVisited = new bool[N,M];
                this.queue = new Queue<int[]>();

                for(int i = 0 ; i < N ; i++)
                {
                    input = Console.ReadLine();
                    for(int j = 0 ; j < M ; j++)
                    {
                        maze[i,j] = int.Parse(input[j].ToString());
                    }
                }
            }

            public void DoBFS()
            {
                queue.Enqueue(new int[]{0, 0});
                isVisited[0,0] = true;

                while(queue.Count > 0)
                {
                    int[] currPos = queue.Dequeue();
                    int step = maze[currPos[0], currPos[1]];
                    isVisited[currPos[0], currPos[1]] = true;

                    if(currPos[0] > 0 && isVisited[currPos[0] - 1, currPos[1]] == false && maze[currPos[0] - 1, currPos[1]] == 1)
                    {
                        queue.Enqueue(new int[]{currPos[0] - 1, currPos[1]});
                        maze[currPos[0] - 1, currPos[1]] = step + 1;
                    }
                    if(currPos[0] < N - 1 && isVisited[currPos[0] + 1, currPos[1]] == false && maze[currPos[0] + 1, currPos[1]] == 1)
                    {
                        queue.Enqueue(new int[]{currPos[0] + 1, currPos[1]});
                        maze[currPos[0] + 1, currPos[1]] = step + 1;
                    }                        
                    if(currPos[1] > 0 && isVisited[currPos[0], currPos[1] - 1] == false && maze[currPos[0], currPos[1] - 1] == 1)
                    {
                        queue.Enqueue(new int[]{currPos[0], currPos[1] - 1});
                        maze[currPos[0], currPos[1] - 1] = step + 1;
                    }                        
                    if(currPos[1] < M - 1 && isVisited[currPos[0], currPos[1] + 1] == false && maze[currPos[0], currPos[1] + 1] == 1)
                    {
                        queue.Enqueue(new int[]{currPos[0], currPos[1] + 1});
                        maze[currPos[0], currPos[1] + 1] = step + 1;
                    }                        
                }

                Console.WriteLine(maze[N-1, M-1]);
            }
        }

        public static void Main(string[] args)
        {
            BFS bfs = new BFS();
            bfs.DoBFS();
        }
    }    
}