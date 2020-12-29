import sys
input = sys.stdin.readline
'''
    memo[i][0] = pinary number end with 0 -> can append 0, 1
    memo[i][1] = pinary number end with 1 -> can append only 0
    (11 -> not allowed)
'''
N = int(input())
memo = [[0] * 2 for _ in range(N)]  # list comprehension
if N == 1 or N == 2:
    print(1)
    sys.exit(0)
if N == 3:
    print(2)
    sys.exit(0)

memo[2][0] = 1          # n = 3, 100
memo[2][1] = 1          # n = 3, 101
for i in range(3, N):   # loop start with n = 4
    memo[i][0] = memo[i - 1][0] + memo[i - 1][1]
    memo[i][1] = memo[i - 1][0]

print(memo[N - 1][0] + memo[N - 1][1])