using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution_1260
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string [] splitStr = input.Split(' ');
            int vertexCnt = int.Parse(splitStr[0]);
            int edgeCnt = int.Parse(splitStr[1]);
            int startVertex = int.Parse(splitStr[2]);
            int [,] adjMatrix = new int[vertexCnt + 1, vertexCnt + 1];

            for(int i = 0 ; i < edgeCnt ; i++)
            {
                input = Console.ReadLine();
                splitStr = input.Split(' ');
                adjMatrix[int.Parse(splitStr[0]), int.Parse(splitStr[1])] = 1;
                adjMatrix[int.Parse(splitStr[1]), int.Parse(splitStr[0])] = 1;
            }

            DFS dfs = new DFS(adjMatrix, vertexCnt);
            dfs.doDFS(startVertex);
            dfs.PrintAnswer();

            BFS bfs = new BFS(adjMatrix, vertexCnt);
            bfs.doBFS(startVertex);
            bfs.PrintAnswer();
        }
    }

    public class DFS
    {
        private int[,] adjMatrix;
        private bool[] IsVisited;
        private string answer;
        private int vertexCnt;

        public DFS(int[,] mat, int vertexCnt)
        {
            this.adjMatrix = mat;
            this.answer = string.Empty;
            this.vertexCnt = vertexCnt;
            this.IsVisited = new bool[vertexCnt + 1];
        }

        public void doDFS(int currentVertex){
            if(IsVisited[currentVertex])
                return;

            this.answer += currentVertex.ToString();
            this.answer += " ";
            IsVisited[currentVertex] = true;

            for(int i = 1 ; i <= this.vertexCnt ; i++)
            {
                if(adjMatrix[currentVertex, i] == 1)
                    doDFS(i);
            }
        }

        public void PrintAnswer()
        {
            Console.WriteLine(answer.Substring(0, answer.Length - 1));
        }
    }

    public class BFS
    {
        private int[,] adjMatrix;
        private bool[] IsVisited;
        private string answer;
        private int vertexCnt;
        private Queue<int> queue;

        public BFS(int[,] mat, int vertexCnt)
        {
            this.adjMatrix = mat;
            this.answer = string.Empty;
            this.vertexCnt = vertexCnt;
            this.IsVisited = new bool[vertexCnt + 1];
            this.queue = new Queue<int>();
        }

        public void doBFS(int startVertex)
        {
            queue.Enqueue(startVertex);
            IsVisited[startVertex] = true;

            while(queue.Count > 0)
            {
                int currentVertex = queue.Dequeue();                
                answer += currentVertex.ToString();
                answer += " ";

                for(int i = 1 ; i <= this.vertexCnt ; i++)
                {
                    if(adjMatrix[currentVertex, i] == 1 && IsVisited[i] == false)
                    {
                        queue.Enqueue(i);
                        IsVisited[i] = true;
                    }                        
                }
            }
        }

        public void PrintAnswer()
        {
            Console.WriteLine(answer.Substring(0, answer.Length - 1));
        }
    }
}