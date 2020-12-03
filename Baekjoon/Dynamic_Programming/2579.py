import sys
'''
    memo[n] = maximum point to step on n-th stair
    but 3-times consecutive stepping is not allowed.

    So,
    memo[n] = stairs[n] + max
    {
        stairs[n-1] + memo[n-3],    //step on n-1 th stair
        memo[n-2]                   //not step on n-1 th stair
    }
'''

N = int(sys.stdin.readline())
stairs = [0] * (N + 1)
memo = [0] * (N + 1)
for i in range(1, N + 1):
    stairs[i] = int(sys.stdin.readline())

if N == 1:
    print(stairs[1])
else:
    memo[1] = stairs[1]
    memo[2] = stairs[1] + stairs[2]
    for i in range(3, N + 1):
        memo[i] = stairs[i] + max(stairs[i - 1] + memo[i - 3], memo[i - 2])
    print(memo[N])