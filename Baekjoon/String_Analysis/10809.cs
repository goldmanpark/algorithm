using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution_10809
    {
        public static void Main(string[] args)
        {
            string word = Console.ReadLine();
            Dictionary<char, int> dic = new Dictionary<char, int>();

            for(char c = 'a' ; c <= 'z' ; c++)
                dic.Add(c, -1);

            for(int i = 0 ; i < word.Length ; i++){
                if(dic[word[i]] == -1)
                    dic[word[i]] = i;
            }

            string answer = string.Empty;
            for(char c = 'a' ; c <= 'z' ; c++)
                answer += (dic[c].ToString() + " ");

            Console.WriteLine(answer.Substring(0, answer.Length - 1));                
        }
    }
}
