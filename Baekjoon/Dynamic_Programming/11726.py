import sys
'''
    n = 1 > 1       (1 vertical tile)
    n = 2 > 1 1     (2 vertical tiles)
            2       (2 horizontal tiles)
    ---------------------------
    n = 3 > 1 (2)       (n = 1)
            1 1 (1)     (n = 2)
            2 (1)
    ---------------------------
    n = 4 > 1 1 (2)     (n = 2)
            2 (2)
            1 1 1 (1)   (n = 3)
            1 2 (1)
            2 1 (1)
    ---------------------------
    memo[N] = memo[N - 2]   # add 2 horizontal tiles to memo[N - 2] form
            + memo[N - 1]   # add 1 vertical tile to memo[N - 1] form
'''

N = int(input())
if N == 1:
    print(1)
    sys.exit(0)
memo = [0 for i in range(N)]
memo[0] = 1
memo[1] = 2
for i in range(2, N):
    memo[i] = (memo[i - 2] + memo[i - 1]) % 10007

print(memo[N - 1])