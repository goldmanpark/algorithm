using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution_1992
    {
		public class QuadTree
		{
			private int size;
			private int [,] matrix;
			private string answer;
			
			public QuadTree()
			{
				size = int.Parse(Console.ReadLine());
				matrix = new int[size, size];
				for(int i = 0 ; i < size ; i++)
				{
					string str = Console.ReadLine();
					for(int j = 0 ; j < size ; j++)
					{
						matrix[i,j] = int.Parse(str[j].ToString());
					}
				}
				answer = string.Empty;
			}
			
			public void Divide()
			{
				Divide(size, 0, 0);
			}
			
			public void Divide(int length, int xPos, int yPos)
			{
				bool flag = true;
				for(int i = xPos ; i < xPos + length ; i++){
					for(int j = yPos ; j < yPos + length ; j++){
						if(matrix[i,j] != matrix[xPos, yPos]){
							flag = false;
							break;
						}
					}
				}
				if(flag)
				{
					if(matrix[xPos, yPos] == 0)
						answer += "0";
					else
						answer += "1";
				}
				else
				{
					int newLength = length / 2;
					answer += "(";
					Divide(newLength, xPos, yPos);
					Divide(newLength, xPos, yPos + newLength);
					Divide(newLength, xPos + newLength, yPos);
					Divide(newLength, xPos + newLength, yPos + newLength);
					answer += ")";
				}
			}
			
			public void Answer()
			{
				Console.WriteLine(answer);
			}
		}
		
        public static void Main(string[] args)
        {
            QuadTree tree = new QuadTree();
			tree.Divide();
			tree.Answer();
        }
    }
}
