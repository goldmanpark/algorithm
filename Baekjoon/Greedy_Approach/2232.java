//Greedy Approach
import java.util.Scanner;

class Mine {
	int mineFieldLength;
	int mineNum;
	int [] mines;
	int [] answer;
	
	Mine(Scanner sc){
		mineNum = mineFieldLength = sc.nextInt();
		mines = new int[mineFieldLength + 2];	//leftmost, rightmost 0
		answer = new int[mineFieldLength];
		
		for(int i = 1 ; i <= mineFieldLength ; i++)
			mines[i] = sc.nextInt();
	}
	
	void sol(){
		int ansIdx = 0;
		while(mineNum > 0){	//loop until no more mines exist
			//1. find mine index which has maximum power
			int maxIdx = 0;
			for(int i = 1 ; i <= mineFieldLength ; i++){
				if(mines[i] > mines[maxIdx])
					maxIdx = i;
			}
			
			//2. explode mine till chaining explosion is finished
			explode(maxIdx);
			answer[ansIdx] = maxIdx;
			ansIdx++;
		}
		//3. sort answer ascending
		int minIdx = 0;
		for(int i = 0 ; i < ansIdx ; i++){
			minIdx = i;
			for(int j = i + 1 ; j < ansIdx ; j++){
				if(answer[j] < answer[minIdx])
					minIdx = j;
			}
			int temp = answer[i];
			answer[i] = answer[minIdx];
			answer[minIdx] = temp;
		}
		//4. print result
		for(int i = 0 ; i < ansIdx ; i++){
			System.out.println(answer[i]);
		}
	}
	
	void explode(int max){
		if(mines[max - 1] < mines[max] && mines[max - 1] > 0)
			explodeLeft(max - 1);
		if(mines[max + 1] < mines[max] && mines[max + 1] > 0)
			explodeRight(max + 1);
		mines[max] = 0;
		mineNum--;
	}
	
	void explodeLeft(int idx){
		if(mines[idx - 1] < mines[idx] && mines[idx - 1] > 0)
			explodeLeft(idx - 1);
		mines[idx] = 0;
		mineNum--;
	}
	
	void explodeRight(int idx){
		if(mines[idx + 1] < mines[idx] && mines[idx + 1] > 0)
			explodeRight(idx + 1);
		mines[idx] = 0;
		mineNum--;
	}
}

public class Main {
	public static void main(String[] args) throws Exception {
		Scanner sc = new Scanner(System.in);
		Mine M = new Mine(sc);
		M.sol();
		sc.close();
	}
}