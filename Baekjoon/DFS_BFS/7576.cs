using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution_7576
    {
        public class BFS
        {
            int N, M;
            int[,] box;
            bool[,] isVisit;
            Queue<int[]> queue;

            public BFS()
            {
                string input = Console.ReadLine();
                string[] spl = input.Split(' ');
                this.M = int.Parse(spl[0]); //Width
                this.N = int.Parse(spl[1]); //Height
                box = new int[N,M];
                isVisit = new bool[N,M];
                queue = new Queue<int[]>();

                for(int i = 0 ; i < N ; i++){
                    input = Console.ReadLine();
                    spl = input.Split(' ');
                    for(int j = 0 ; j < M ; j++){
                        box[i,j] = int.Parse(spl[j]);
                        if(box[i,j] == 1){
                            queue.Enqueue(new int[] {i, j});
                            isVisit[i,j] = true;
                        }
                    }
                }
            }

            public void DoBFS()
            {
                int answer = 0;

                while(queue.Count > 0)
                {
                    int[] curr = queue.Dequeue();
                    int x = curr[0];
                    int y = curr[1];
                    answer = box[x, y];

                    if(x > 0 && isVisit[x - 1, y] == false && box[x - 1, y] == 0){
                        isVisit[x - 1, y] = true;
                        box[x - 1, y] = 1 + answer;
                        queue.Enqueue(new int[]{x - 1, y});
                    }
                    if(x < N - 1 && isVisit[x + 1, y] == false && box[x + 1, y] == 0){
                        isVisit[x + 1, y] = true;
                        box[x + 1, y] = 1 + answer;
                        queue.Enqueue(new int[]{x + 1, y});
                    }
                    if(y > 0 && isVisit[x, y - 1] == false && box[x, y - 1] == 0){
                        isVisit[x, y - 1] = true;
                        box[x, y - 1] = 1 + answer;
                        queue.Enqueue(new int[]{x, y - 1});
                    }
                    if(y < M - 1 && isVisit[x, y + 1] == false && box[x, y + 1] == 0){
                        isVisit[x, y + 1] = true;
                        box[x, y + 1] = 1 + answer;
                        queue.Enqueue(new int[]{x, y + 1});
                    }
                }
                answer--;//answer start from 0

                //Verification
                for(int i = 0 ; i < N ; i++){
                    for(int j = 0 ; j < M ; j++){
                        if(box[i,j] == 0){
                            answer = -1;
                            goto OUT;
                        }
                    }
                } OUT:

                Console.WriteLine(answer);
            }
        }

        public static void Main(string[] args)
        {
            BFS bfs = new BFS();
            bfs.DoBFS();
        }
    }
}