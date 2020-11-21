val = input().split()
N = int(val[0])
M = int(val[1])

def BackTrack(stack, num, currHeight):
    stack[currHeight] = num
    if currHeight == M:
        answer = ''
        for i in range(1, M + 1):
            answer += (str(stack[i]) + ' ')
        print(answer)
    else:
        for i in range(num + 1, N + 1):
            BackTrack(stack, i, currHeight + 1)
    stack[currHeight] = 0

stack = [0] * (M + 1)
BackTrack(stack, 0, 0)