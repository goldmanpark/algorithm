using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution_9012
    {
        public static void Main(string[] args)
        {
            int inputSize = int.Parse(Console.ReadLine());
            string [] strs = new string[inputSize];
            for(int i = 0 ; i < inputSize ; i++){
                strs[i] = Console.ReadLine();
            }
            
            for(int i = 0 ; i < inputSize ; i++){
                Stack<int> stack = new Stack<int>();
                bool flag = true;

                for(int j = 0 ; j < strs[i].Length ; j++){
                    if(strs[i][j] == '(')
                        stack.Push(1);
                    else{
                        if(stack.Count == 0){
                            flag = false;
                            break;
                        }                            
                        else
                            stack.Pop();
                    }                        
                }

                if(stack.Count != 0 || flag == false)
                    Console.WriteLine("NO");
                else
                    Console.WriteLine("YES");
            }
        }
    }
}
