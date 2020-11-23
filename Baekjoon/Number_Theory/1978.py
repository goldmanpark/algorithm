import sys

def IsPrime(number):
    for i in range(2, number - 1):
        if number % i == 0:
            return 0
    return 1

N = int(sys.stdin.readline())
inStr = str(sys.stdin.readline()).split()
answer = 0
for i in range(N):
    if int(inStr[i]) != 1:
        answer += IsPrime(int(inStr[i]))

print(answer)