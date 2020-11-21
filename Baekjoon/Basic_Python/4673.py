def SelfNumber(i):
    selfnum = i
    for x in str(i):
        selfnum += int(x)
    return selfnum

list = [0 for i in range(10100)] #max selfnumber of 9999 = 
for i in range(10000):
    list[SelfNumber(i)] = -1

for x in range(10000):
    if list[x] == 0:
        print(x)

