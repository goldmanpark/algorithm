x = inputNum = int(input()) 
i = 1
a = b = 0

while True:
    if x < 10:
        a = 0
        b = x
    else:
        a = int(x / 10)
        b = x % 10

    x = b * 10 + (a + b) % 10
    
    if x == inputNum:
        break
    else:
        i += 1
    
print(i)