using System;

namespace Solution
{
    public class Solution_1074
    {
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
            int len = (int)Math.Pow(2, N);
            
            GetAnswer(0, 0, len);
            Console.WriteLine(answer);
        }

        public static void GetAnswer(int h, int w, int len)
        {
            if(answerFlag)
                return;
            else{
                if(len == 1){
                    answer++;
                    if(h == R && w == C)
                        answerFlag = true;
                }
                else{
                    int newLen = len / 2;
                    if(R < h + newLen && C < w + newLen){         //if (R,C) in 1st quadrant
                        GetAnswer(h, w, newLen);
                    }
                    else if(R < h + newLen && C >= w + newLen){   //if (R,C) in 2nd quadrant
                        answer += newLen * newLen;
                        GetAnswer(h, w + newLen, newLen);
                    }
                    else if(R >= h + newLen && C < w + newLen){   //if (R,C) in 3rd quadrant
                        answer += newLen * newLen * 2;
                        GetAnswer(h + newLen, w, newLen);
                    }
                    else if(R >= h + newLen && C >= w + newLen){  //if (R,C) in 4th quadrant
                        answer += newLen * newLen * 3;
                        GetAnswer(h + newLen, w + newLen, newLen);
                    }
                }
            }
        }
    }
}