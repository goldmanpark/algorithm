using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution
{
    public class Solution_1427
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> list = new List<int>();

            for(int i = 0 ; i < input.Length ; i++){
                list.Add(int.Parse(input[i].ToString()));
            }

            list = list.OrderByDescending(x => x).ToList();
            list.ForEach(x => Console.Write(x));
        }
    }
}
