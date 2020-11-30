import sys

def IsPrime(number):
    for i in range(2, number - 1):
        if number % i == 0:
            return False
    return True

M = int(sys.stdin.readline())
N = int(sys.stdin.readline())
answer = 0
minVal = sys.maxsize

# 1 is not prime number
if M == 1:  
    M += 1

for i in range(M, N + 1):
    if IsPrime(i) == True:
        answer += i
        if i < minVal:
            minVal = i

if answer == 0:
    print(-1)
else:
    print(answer)
    print(minVal)