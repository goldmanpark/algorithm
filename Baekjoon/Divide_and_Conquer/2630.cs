using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution_2630
    {
		private static int whiteCnt = 0;
		private static int blueCnt = 0;
		private static int size;
		private static int [,] arr;
		
        public static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());
			arr = new int[size, size];
			for(int i = 0 ; i < size ; i++){
				string input = Console.ReadLine();
				string[] numbers = input.Split(' ');
				
				for(int j = 0 ; j < size ; j++){
					arr[i, j] = int.Parse(numbers[j]);
				}
			}			
			
			Cut(size, 0, 0);
			
			Console.WriteLine(whiteCnt);
			Console.WriteLine(blueCnt);
        }
		
		private static void Cut(int length, int xPos, int yPos)
		{
			if(length == 1){
				if(arr[xPos, yPos] == 0)
					whiteCnt++;
				else
					blueCnt++;
			}
			else{
				bool flag = true;
					
				for(int i = xPos ; i < xPos + length ; i++){
					for(int j = yPos ; j < yPos + length ; j++){
						if(arr[i,j] != arr[xPos, yPos]){
							flag = false;
							break;
						}
					}
				}
				
				if(flag){
					if(arr[xPos, yPos] == 0)
						whiteCnt++;
					else
						blueCnt++;
				}
				else{
					int newLen = length / 2;
					Cut(newLen, xPos, yPos);
					Cut(newLen, xPos + newLen, yPos);
					Cut(newLen, xPos, yPos + newLen);
					Cut(newLen, xPos + newLen, yPos + newLen);
				}
			}	
		}
    }
}
