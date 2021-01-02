import sys
import heapq
input = sys.stdin.readline
INF = sys.maxsize

'''
    Dijkstra algorithm using priority queue
    N : number of cities(vertex)
    M : roads(edge)
    K : answer condition
    X : start city(vertex)
'''
N, M, K, X = map(int, input().split())
graph = [[] for _ in range(N + 1)]
distance = [INF] * (N + 1)
heap = []

for _ in range(M):
    start, end = map(int, input().split())
    graph[start].append((end, 1))   # start -> end, weight=1

heapq.heappush(heap, (0, X))
distance[X] = 0

while len(heap) > 0:
    road, city = heapq.heappop(heap)
    if distance[city] < road:
        continue
    for edge in graph[city]:
        cost = road + edge[1]
        if cost < distance[edge[0]]:
            distance[edge[0]] = cost
            heapq.heappush(heap, (cost, edge[0]))

flag = False
for i in range(N + 1):
    if distance[i] == K:
        print(i)
        flag = True

if flag == False:
    print(-1)