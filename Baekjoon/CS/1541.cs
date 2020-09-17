using System;
using System.Collections.Generic;

namespace Solution
{
	public class Solution_1541
	{
		public static void Main(string[] args)
		{
			string str = Console.ReadLine();
			List<int> list = new List<int>();
			
			string tempStr = string.Empty;
			bool operFlag = true; // means '+'
			for(int i = 0 ; i < str.Length ; i++)
			{
				if(str[i] >= '0' && str[i] <= '9')
					tempStr += str[i];
				if(str[i] == '+' || str[i] == '-' || i == str.Length - 1)
				{
					int tempInt = operFlag ? int.Parse(tempStr) : -1 * int.Parse(tempStr);
					list.Add(tempInt);
					tempStr = string.Empty;
					
					if(str[i] == '+')
						operFlag = true;
					else if(str[i] == '-')
						operFlag = false;
				}
			}
			
			int answer = list[0];
			for(int i = 1 ; i < list.Count ; i++)
			{
				if(list[i - 1] < 0)
				{
					if(list[i] > 0)
						list[i] = -1 * list[i];
				}
					answer += list[i];
			}
			Console.WriteLine(answer);
		}
	}
}