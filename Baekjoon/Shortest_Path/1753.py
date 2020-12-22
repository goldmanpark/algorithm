import sys
import heapq as hq

# Dijkstra algorithm using priority queue

input = sys.stdin.readline
INF = sys.maxsize

V, E = map(int, input().split())
K = int(input())
graph = [[] for row in range(V + 1)]
distance = [INF] * (V + 1)

for _ in range(E):
    u, v, w = map(int, input().split())
    graph[u].append((v, w)) # from u to v, weight w

heap = []                   # min heap, tuple: (distance, vertex)
hq.heappush(heap, (0, K))   # push start vertex
distance[K] = 0

while len(heap) > 0:
    dist, vertex = hq.heappop(heap)
    if distance[vertex] < dist:
        continue
    for edge in graph[vertex]:  # edge[0] = target vertex
        cost = dist + edge[1]   # edge[1] = weight
        if cost < distance[edge[0]]:
            distance[edge[0]] = cost
            hq.heappush(heap, (cost, edge[0]))

for i in range(1, V + 1):
    if distance[i] != INF:
        print(distance[i])
    else:
        print('INF')