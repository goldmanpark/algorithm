import sys
input = sys.stdin.readline

N = int(input())
A2 = A5 = 0

if N >= 5:
    if N % 5 % 2 == 0:
        A5 = N // 5
        A2 = (N % 5) // 2
    else:
        A5 = N // 5 - 1
        A2 = (N % 5 + 5) // 2
    print(int(A2) + A5)
    
else:
    if N % 2 == 0:
        A2 = N // 2
        print(int(A2) + A5)
    else:
        print(-1)