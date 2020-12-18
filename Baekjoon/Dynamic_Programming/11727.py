import sys
'''
    tile types: A (1 vertical tile)
                B (2 vertical tiles)
                C (1 square tile)
    ---------------------------
    n = 1 > A
    n = 2 > A A
            B
            C
    ---------------------------
    n = 3 > A (B)       (n = 1)
            A (C)
            A A (A)     (n = 2)
            B (A)
            C (A)
    ---------------------------
    memo[N] = memo[N - 2] * 2   # add 2 horizontal tiles or 1 square tile to memo[N - 2] form
            + memo[N - 1]       # add 1 vertical tile to memo[N - 1] form
'''

N = int(input())
if N == 1:
    print(1)
    sys.exit(0)
memo = [0 for i in range(N)]
memo[0] = 1
memo[1] = 3
for i in range(2, N):
    memo[i] = (memo[i - 2] * 2 + memo[i - 1]) % 10007

print(memo[N - 1])