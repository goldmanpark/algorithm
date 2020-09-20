import java.util.Scanner;

public class Main{
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int a = sc.nextInt();
        String numbers = sc.next();
        int sum = 0;
        
        for (int i = 0; i < a; i++){
        	int temp = Character.digit(numbers.charAt(i), 10);
        	sum += temp;
        }
        System.out.println(sum);
        sc.close();
    }
}