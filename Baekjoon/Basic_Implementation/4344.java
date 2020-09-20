import java.util.Scanner;

public class Main{
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int testCase = sc.nextInt();
        int num = 0;
        int scores[] = null;


        for(int  i = 0 ; i < testCase ; i++){
            num = sc.nextInt();
            scores = new int[num];
            int sum = 0;
            int avg = 0;
			int over = 0;

            for(int j = 0 ; j < num ; j++){
                scores[j] = sc.nextInt();
                sum += scores[j];
            }

            avg = sum / num;

			for(int j = 0 ; j < num ; j++){
                if(scores[j] > avg)
					over++;
            }

			System.out.format("%.3f", (float)over / (float)num * 100);
			System.out.println("%");
        }

		sc.close();
    }
}