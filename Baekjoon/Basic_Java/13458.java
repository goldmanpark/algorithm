//https://www.acmicpc.net/problem/13458
import java.util.Scanner;
//import java.io.FileInputStream;

class Qset {
	int[] a;
	int n, b, c;

	Qset(int caseNum, Scanner sc) {
		n = caseNum;
		a = new int[n];
		for (int i = 0; i < n; i++)
			a[i] = sc.nextInt();
		b = sc.nextInt();
		c = sc.nextInt();
	}

	void getSolution() {
		long answer = n;

		// 1. send supervisors to all test sites
		for (int i = 0; i < n; i++)
			a[i] -= b;

		// 2. send sub-supervisors to all test sites
		for (int i = 0; i < n; i++) {
			if (a[i] > 0) {
				answer += (int) (a[i] / c);
				if (a[i] % c > 0)
					answer++;
			}
		}

		System.out.println(answer);
	}
}

public class Main {
	public static void main(String[] args) throws Exception {
		Scanner sc = new Scanner(System.in);
		//Scanner sc = new Scanner(new FileInputStream("C:\\Users\\student\\workspace2\\fuck\\src\\fuck\\input.txt"));
		int caseNum = sc.nextInt();

		Qset Q = new Qset(caseNum, sc);
		Q.getSolution();
		sc.close();
	}
}
