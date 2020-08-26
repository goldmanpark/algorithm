using System;

namespace Solution
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            int startInt = int.Parse(Console.ReadLine());
            int kg3 = 0;
            int kg5 = 0;

            kg5 = startInt / 5;

            if (startInt % 5 == 0)
                Console.WriteLine(kg5);
            else{
                while(kg5 >= 0){
                    kg3 = (startInt - kg5 * 5 ) / 3;
                    
                    if((startInt - kg5 * 5 ) % 3 == 0)
                        break;

                    kg5--;
                }

                if (startInt - kg5 * 5 - kg3 * 3 == 0)
                    Console.WriteLine(kg3 + kg5);
                else
                    Console.WriteLine(-1);
            }            
        }
    }
}
