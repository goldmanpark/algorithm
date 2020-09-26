using System;
using System.Linq;

//1st Try -> Timeout Failed
namespace Solution
{
    public class Solution_1931
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] list = new int[size][];

            for(int i = 0 ; i < size ; i++)
            {
                string tempStr = Console.ReadLine();
                string [] tempStr2 = tempStr.Split(' ');
                int [] tempInt = new int[2];
                tempInt[0] = int.Parse(tempStr2[0]);
                tempInt[1] = int.Parse(tempStr2[1]);

                if(!list.Contains(tempInt))
                    list.Append(tempInt);
            }

            int answer = 1;
            int lastIdx = 0;
            list = list.OrderBy(x => x[1]).ToArray();
            for(int i = 1 ; i < list.Length ; i++)
            {
                if(list[lastIdx][1] < list[i][0])
                {
                    answer++;
                    lastIdx = i;
                }
            }

            Console.WriteLine(answer);
        }
    }
}