import sys

# Sieve of Eratosthenes
# 2020.11.30 timeout

val = sys.stdin.readline().split()
M = int(val[0])
N = int(val[1])
answer = list(range(M, N + 1))
if answer[0] == 1:
    del answer[0]

for i in range(2, N):
    for j in range(2, N):
        notPrime = i * j
        if notPrime > N:
            break
        elif notPrime in answer:
            answer.remove(notPrime)

for element in answer:
    print(element)
        