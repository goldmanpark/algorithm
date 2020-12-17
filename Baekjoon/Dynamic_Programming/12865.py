import sys

# knapsack problem
'''
    memo[i][w] = max value, considering item 1 ~ i and max weight 'w'
    memo[i][w] = max(
        memo[i-1][w],                                 # if the i-th item is not put
        memo[i-1][w - item[i].weight] + item[i].value # if the i-th item is put
        )
'''

class Item:
    def __init__(self, w, v):
        self.weight = w
        self.value = v

inputStr = sys.stdin.readline().split()
N = int(inputStr[0]) # number of items
K = int(inputStr[1]) # maximum weight
items = []


for i in range(N):
    inputStr = sys.stdin.readline().split()
    item = Item(inputStr[0], inputStr[1])
    items.append(item)

items.sort(key=lambda x: x.weight)
