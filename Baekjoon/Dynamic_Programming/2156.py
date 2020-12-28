import sys
input = sys.stdin.readline
'''
    condition: do not drink 3-continous wines
'''
N = int(input())
wines = [0] * N
memo = [0] * N
for i in range(N):
    wines[i] = int(input())

memo[0] = wines[0]
if N == 1:
    print(memo[0])
    sys.exit(0)

memo[1] = wines[0] + wines[1]
if N == 2:
    print(memo[1])
    sys.exit(0)

for i in range(2, N):
    A1 = memo[i - 1]                            # not drink i_th
    A2 = wines[i] + memo[i - 2]                 # not drink i-1_th
    A3 = wines[i] + wines[i - 1] + memo[i - 3]  # not drink i-2_th
    memo[i] = max(A1, A2, A3)

print(memo[N - 1])