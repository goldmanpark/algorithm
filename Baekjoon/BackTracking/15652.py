val = input().split()
N = int(val[0])
M = int(val[1])

def BackTrack(stack, num, currHeight):
    stack[currHeight] = num
    if currHeight == M - 1:
        print(*stack)
    else:
        for i in range(num, N + 1):
            BackTrack(stack, i, currHeight + 1)
    stack[currHeight] = 0

stack = [0] * M
for i in range(1, N + 1):
    BackTrack(stack, i, 0)