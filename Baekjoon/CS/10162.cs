using System;

namespace Solution
{
    public class Solution_10162
    {
        public static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
			int A = 0;
			int B = 0;
			int C = 0;
			string answer = string.Empty;
			
			A = T / 300;
			if(A > 0)
				T = T - A * 300;
			
            B = T / 60;
			if(B > 0)
				T = T - B * 60;
			
			C = T / 10;
			if(C > 0)
				T = T - C * 10;
			
			if(T == 0)
				answer = A + " " + B + " " + C;
			else
				answer = "-1";
			
            Console.WriteLine(answer);
        }
    }
}
