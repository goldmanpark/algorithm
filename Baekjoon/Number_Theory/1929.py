import sys
import math

# Sieve of Eratosthenes

val = sys.stdin.readline().split()
M = int(val[0])
N = int(val[1])
if M == N == 1:
    sys.exit(0)
numbers = list(range(M, N + 1))
isPrime = [True for x in range(M, N + 1)]
startIdx = 0    # 2,3,4,5.. startIdx = 0, 1,2,3,4..startIdx = 0

# 1. remove 1
if numbers[0] == 1:
    del isPrime[0]
    del numbers[0]

# 2. remove multiples of 2
startIdx = 0 if numbers[0] % 2 == 0 else 1
for i in range(startIdx, len(numbers), 2):
    isPrime[i] = False
if numbers[0] == 2: # 2 is the only even prime number
    isPrime[0] = True

# 3. remove multiples of odd numbers(3 ~ sqrt(N))
odd = 3
sqrt = int(math.sqrt(N))
while odd <= sqrt:
    startIdx = 1 if numbers[0] % 2 == 0 else 0
    for i in range(startIdx, len(numbers), 2):
        if numbers[i] == odd:
            continue
        if numbers[i] % odd == 0:
            isPrime[i] = False
    odd += 2

for i in range(len(numbers)):
    if isPrime[i] == True:
        print(numbers[i])