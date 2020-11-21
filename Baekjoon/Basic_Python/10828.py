import sys

stack = []
cnt = int(input())

for i in range(cnt):
    cmd = str(sys.stdin.readline().rstrip())    #fast input
    if cmd == 'pop':
        if len(stack) == 0:
            print(-1)
        else:
            print(stack[-1])
            del stack[-1]
    elif cmd == 'size':
        print(len(stack))
    elif cmd == 'empty':
        if len(stack) == 0:
            print(1)
        else:
            print(0)
    elif cmd == 'top':
        if len(stack) == 0:
            print(-1)
        else:
            print(stack[-1])
    else:   # push X
        stack.append(cmd.split()[1])