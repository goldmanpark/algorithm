using System;
/*
    Modular Operation
    (a+b) mod m = ((a mod m) + (b mod m)) mod m
    (a*b) mod m = ((a mod m) * (b mod m)) mod m

    Therefore,
    (a^1) mod m = a mod m
    (a^2) mod m = ((a mod m) * (a mod m)) mod m
    (a^3) mod m = ((a^2 mod m) * (a mod m)) mod m
    (a^4) mod m = ((a^2 mod m) * (a^2 mod m)) mod m
*/
namespace Solution
{
    public class Solution_1629
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] spl = input.Split(' ');
            ulong A = Convert.ToUInt64(spl[0]);
            ulong B = Convert.ToUInt64(spl[1]);
            ulong C = Convert.ToUInt64(spl[2]);

            Console.WriteLine(powerAndMod(A, B, C));
        }

        private static ulong powerAndMod(ulong a, ulong b, ulong c){
            if(b == 1)
                return a % c;
            else if(b % 2 == 0)
                return powerAndMod((a % c) * (a % c), b / 2, c);
            else
                return ((a % c) * powerAndMod(a, b - 1, c)) % c;
        }
    }
}
