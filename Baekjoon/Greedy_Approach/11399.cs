using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution_11399
    {
        public static void Main(string[] args)
        {
            int inputSize = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();
            int answer = 0;
            int acc = 0;

            string inputLine = Console.ReadLine();
            string [] tokens = inputLine.Split(' ');
            foreach (var item in tokens)
            {
                list.Add(int.Parse(item));
            }
            list.Sort();
            list.ForEach((x) => {acc += x; answer += acc;});

            Console.WriteLine(answer);
        }
    }
}
