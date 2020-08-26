using System;

namespace Solution
{
    class Solution
    {
        public static void Main(string[] args)
        {
            int startInt = int.Parse(Console.ReadLine());
            int x, y, z;
            int i = 0;
            int newInt = startInt;
            
            do{
                i++;
                if (newInt < 10){
                    x = 0;
                    y = newInt;
                }
                else{
                    x = newInt / 10;
                    y = newInt % 10;
                }
                z = x + y;
                newInt = y * 10 + z % 10;
            }while(startInt != newInt);

            Console.WriteLine(i);
        }
    }
}
