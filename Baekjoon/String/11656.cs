using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution_11656
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> list = new List<string>();

            list.Add(input);
            for(int i = 1 ; i < input.Length ; i++){
                list.Add(input.Substring(input.Length - i, i));
            }

            list.Sort();
            list.ForEach(x => Console.WriteLine(x));
        }
    }
}
