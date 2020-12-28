import sys
input = sys.stdin.readline

#Not Complete

N = int(input())
arr = input().split()
memo = [0] * N
memo[0] = 1

if N == 1:
    print(memo[0])
    sys.exit(0)

last = arr[0]
for i in range(1, N):
    if arr[i] > last:
        memo[i] = memo[i - 1] + 1
        last = arr[i]
    else:
        memo[i] = memo[i - 1]

print(memo[N - 1])