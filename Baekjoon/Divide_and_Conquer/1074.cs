using System;
// Not Optimized(Memory consumption is too high)
namespace Solution
{
    public class Solution_1074
    {
        static int[,] rectangle;
        static int R, C;
        static int answer = -1;
        static bool answerFlag = false;

        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] spl = input.Split(' ');
            int N = int.Parse(spl[0]);
            R = int.Parse(spl[1]);
            C = int.Parse(spl[2]);
            int len = (int)Math.Pow(2, N) / 2; // 2^15 occurs OutOfMemoryException

            rectangle = new int[len, len];
            if(R < len && C < len){         //1st quadrant
                // do nothing
            }
            else if(R < len && C >= len){   //2nd quadrant
                C -= len;
                answer += len * len;
            }
            else if(R >= len && C < len){   //3rd quadrant
                R -= len;
                answer += len * len * 2;
            }
            else if(R >= len && C >= len){  //4th quadrant
                C -= len;
                R -= len;
                answer += len * len * 3;
            }
            
            GetAnswer(0, 0, len);
            Console.WriteLine(answer);
        }

        public static void GetAnswer(int h, int w, int len)
        {
            if(answerFlag)
                return;
            if(len == 1){
                rectangle[h, w] = ++answer;
                if(h == R && w == C)
                    answerFlag = true;
            }
            else{
                int newLen = len / 2;
                GetAnswer(h, w, newLen);
                GetAnswer(h, w + newLen, newLen);
                GetAnswer(h + newLen, w, newLen);                
                GetAnswer(h + newLen, w + newLen, newLen);
            }
        }
    }
}