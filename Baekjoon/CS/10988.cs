using System;

namespace Solution
{
    public class Solution_10988
    {
        public static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int answer = 1;

            for(int i = 0 ; i < str.Length / 2 ; i++){
                if(str[i] == str[str.Length - 1 - i])
                    continue;
                else{
                    answer = 0;
                    break;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
