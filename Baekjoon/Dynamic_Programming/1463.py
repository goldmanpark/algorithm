import sys

# memo[i] = min calc count to get number 'i'

N = int(sys.stdin.readline())
memo = [sys.maxsize] * (N + 1)
memo[N] = 0
    
for i in range(N - 1, 0, -1):
    memo[i] = memo[i + 1] + 1
    if i * 2 <= N:
        memo[i] = min(memo[i], memo[i * 2] + 1)
    if i * 3 <= N:
        memo[i] = min(memo[i], memo[i * 3] + 1)

print(memo[1])