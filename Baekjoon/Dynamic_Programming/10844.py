N = int(input())

memo = [[0 for col in range(10)] for row in range(N)]
for i in range(1, 10):
    memo[0][i] = 1

for i in range(1, N):
    memo[i][0] = memo[i - 1][1]
    memo[i][1] = memo[i - 1][0] + memo[i - 1][2]
    memo[i][2] = memo[i - 1][1] + memo[i - 1][3]
    memo[i][3] = memo[i - 1][2] + memo[i - 1][4]
    memo[i][4] = memo[i - 1][3] + memo[i - 1][5]
    memo[i][5] = memo[i - 1][4] + memo[i - 1][6]
    memo[i][6] = memo[i - 1][5] + memo[i - 1][7]
    memo[i][7] = memo[i - 1][6] + memo[i - 1][8]
    memo[i][8] = memo[i - 1][7] + memo[i - 1][9]
    memo[i][9] = memo[i - 1][8]
        
answer = 0
for i in range(10):
    answer += memo[-1][i]
print(answer % 1000000000)