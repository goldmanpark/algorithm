import sys
import heapq as hq

def dijkstra(end):
    queue = []
    

inputStr = sys.stdin.readline().split()
V = int(inputStr[0])
E = int(inputStr[1])
graph = [[0 for col in range(V + 1)] for row in range(V + 1)]

for i in range(E):
    inputStr = sys.stdin.readline().split()
    u = int(inputStr[0])
    v = int(inputStr[1])
    w = int(inputStr[2])
    graph[u][v] = w