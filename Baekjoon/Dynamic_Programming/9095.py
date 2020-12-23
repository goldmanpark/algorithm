import sys
input = sys.stdin.readline
'''
    n = 1 > 1
    n = 2 > 1 + 1
            2
    n = 3 > 1 + 1 + 1
            1 + 2
            2 + 1            
            3
    -----------------------------------
    n = 4 > 1 + 1 + 1 + 1   (n = 3) + 1
            1 + 2 + 1
            2 + 1 + 1
            3 + 1
            ---------------------------
            1 + 1 + 2       (n = 2) + 2
            2 + 2
            ---------------------------
            1 + 3           (n = 1) + 3
'''

T = int(input())        # number of test cases
n = []                  # numbers
for _ in range(T):
    n.append(int(input()))
m = max(n)              # maximum number
memo = [0] * 11         # question condition: number < 11
memo[1] = 1             # tabulation
memo[2] = 2
memo[3] = 4

for i in range(4, m + 1):
    memo[i] = memo[i - 1] + memo[i - 2] + memo[i - 3]

for i in n:
    print(memo[i])