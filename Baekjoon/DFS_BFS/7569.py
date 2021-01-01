import sys
from collections import deque
input = sys.stdin.readline

# box[H][R][C] 

class BFS:
    def __init__(self):
        self.C, self.R, self.H = map(int, input().split())
        self.box = [[[0 for col in range(self.C)] for row in range(self.R)] for height in range(self.H)]
        self.queue = deque()
        self.unripen = 0

        for h in range(self.H):
            for r in range(self.R):
                inptStr = list(map(int, input().split()))
                for c in range(self.C):
                    self.box[h][r][c] = inptStr[c]
                    if self.box[h][r][c] == 1:
                        self.queue.append([h, r, c])
                    if self.box[h][r][c] == 0:
                        self.unripen += 1
    def doBFS(self):
        answer = 1
        while self.queue:
            curPos = self.queue.popleft()
            h = curPos[0]
            r = curPos[1]
            c = curPos[2]
            answer  = self.box[h][r][c]

            if r > 0 and self.box[h][r - 1][c] == 0:
                self.box[h][r - 1][c] = answer + 1
                self.queue.append([h, r - 1, c])
                self.unripen -= 1
            
            if r < self.R - 1 and self.box[h][r + 1][c] == 0:
                self.box[h][r + 1][c] = answer + 1
                self.queue.append([h, r + 1, c])
                self.unripen -= 1

            if c > 0 and self.box[h][r][c - 1] == 0:
                self.box[h][r][c - 1] = answer + 1
                self.queue.append([h, r, c - 1])
                self.unripen -= 1
            
            if c < self.C - 1 and self.box[h][r][c + 1] == 0:
                self.box[h][r][c + 1] = answer + 1
                self.queue.append([h, r, c + 1])
                self.unripen -= 1

            if h > 0 and self.box[h - 1][r][c] == 0:
                self.box[h - 1][r][c] = answer + 1
                self.queue.append([h - 1, r, c])
                self.unripen -= 1

            if h < self.H - 1 and self.box[h + 1][r][c] == 0:
                self.box[h + 1][r][c] = answer + 1
                self.queue.append([h + 1, r, c])
                self.unripen -= 1
        
        if self.unripen == 0:
            print(answer - 1)   # answer start from 0
        else:
            print(-1)           # failed

bfs = BFS()
bfs.doBFS()