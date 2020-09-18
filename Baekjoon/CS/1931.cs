using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution
{
    public class Solution_1931
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            List<int[]> list = new List<int[]>();            

            for(int i = 0 ; i < size ; i++)
            {
                int [] temp = new int[2];
                string tempStr = Console.ReadLine();
                string [] tempStr2 = tempStr.Split(' ');
                temp[0] = int.Parse(tempStr2[0]);
                temp[1] = int.Parse(tempStr2[1]);
                //temp[2] = temp[1] - temp[0];
                
                // if(!list.Contains(temp))
                //     list.Add(temp);
            }

            int answer = 1;
            //List<int[]> answerList = new List<int[]>(); 
            int lastIdx = 0;
            list = list.OrderBy(x => x[0]).ToList();
            for(int i = 1 ; i < size ; i++)
            {
                // var nested = answerList.Where(x => ((x[0] < list[i][0] && list[i][0] < x[1]) || 
                //                                     (x[0] < list[i][1] && list[i][1] < x[1]) || 
                //                                     (x[0] > list[i][0] && list[i][1] > x[1]))).FirstOrDefault();
                // if(nested == null)
                // {
                //     answer++;
                //     answerList.Add(list[i]);
                // }
                if(list[lastIdx][1] < list[i][0])
                {
                    answer++;
                    lastIdx = i;
                }
            }

            Console.WriteLine(answer);
            //answerList.ForEach((x) => {Console.WriteLine(string.Format(x[0].ToString() + " " + x[1]));});
        }
    }
}