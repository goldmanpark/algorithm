using System;
using System.Collections.Generic;

namespace Solution
{
    class Solution
    {
        public static void Main(string[] args)
        {
            int inputSize = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();
            for(int i = 0 ; i < inputSize ; i++){
                list.Add(int.Parse(Console.ReadLine()));
            }

            list.Sort();
            for(int i = 0 ; i < inputSize ; i++){
                Console.WriteLine(list[i]);
            }
        }
    }
}
