import sys
input = sys.stdin.readline

# Longest Increasing Subsequence
# O(n^2) algorithm

N = int(input())
arr = [0]
arr.extend(list(map(int, input().split())))
memo = [0] * (N + 1)

for i in range(1, N + 1):
    last = 0
    for j in range(i):
        if arr[j] < arr[i] and memo[last] <= memo[j]:
            last = j
        memo[i] = memo[last] + 1

print(max(memo))