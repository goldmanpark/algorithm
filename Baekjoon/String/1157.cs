using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution_1157
    {
        public static void Main(string[] args)
        {
            string str = Console.ReadLine();
			str = str.ToUpper();
			Dictionary<char, int> dic = new Dictionary<char, int>();
			
			for(char i = 'A' ; i <= 'Z' ; i++){
				dic.Add(i, 0);
			}
			
			for(int i = 0 ; i < str.Length ; i++){
				dic[str[i]]++;
			}
			
			string answer = string.Empty;
			int maxVal = 0;
			foreach(var key in dic.Keys){
				if(dic[key] > maxVal){
					answer = string.Empty;
					answer += key;
					maxVal = dic[key];
				}
				else if(dic[key] == maxVal){
					answer += key;
					maxVal = dic[key];
				}	
			}
			
			if(answer.Length == 1)
            	Console.WriteLine(answer[0]);
			else if(answer.Length > 1)
            	Console.WriteLine("?");
        }
    }
}
