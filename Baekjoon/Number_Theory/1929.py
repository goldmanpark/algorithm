import sys
import math

# Sieve of Eratosthenes

val = sys.stdin.readline().split()
M = int(val[0])
N = int(val[1])
answer = list(range(M, N + 1))

# 1. remove 1
if answer[0] == 1:
    del answer[0]
# 2. remove multiples of 2
for x in answer:
    if x % 2 == 0:
        answer.remove(x)
# 3. remove multiples of odd numbers(3 ~ sqrt(N))
odd = 3
sqrt = int(math.sqrt(N))
while odd <= sqrt:
    for x in answer:
        if x == odd:
            continue
        if x % odd == 0:
            answer.remove(x)
    odd += 2

for x in answer:
    print(x)