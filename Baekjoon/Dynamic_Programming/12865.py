import sys

'''
    # the knapsack problem
    memo[w][i] = max value, considering knapsack loadable weight is 'w' and item 1 ~ i
    memo[w][i] = max(
        memo[w][i-1],                       # if the i-th item is not put
        memo[w - weight[i]][i-1] + value[i] # if the i-th item is put
        )
'''

inputStr = sys.stdin.readline().split()
N = int(inputStr[0])                    # number of items
K = int(inputStr[1])                    # maximum weight
weight = [0 for i in range(N + 1)]      # index of items: 1 ~ N
value = [0 for i in range(N + 1)]
memo = [[0 for col in range(N + 1)] for row in range(K + 1)]

for i in range(1, N + 1):
    inputStr = sys.stdin.readline().split()
    weight[i] = int(inputStr[0])
    value[i] = int(inputStr[1])

for w in range(1, K + 1):       # pivot: loadable weight
    for i in range(1, N + 1):
        if weight[i] > w:
            memo[w][i] = memo[w][i - 1]
        else:
            memo[w][i] = max(memo[w][i - 1], memo[w - weight[i]][i - 1] + value[i])

print(memo[K][N])
