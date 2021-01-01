import sys
input = sys.stdin.readline
# box[H][R][C] 
# Failed
class Queue:
    def __init__(self):
        self.queue = []
    def enqueue(self, x):
        self.queue.append(x)
    def dequeue(self):
        val = self.queue[0]
        del self.queue[0]
        return val   
    def getSize(self):
        return len(self.queue)

class BFS:
    def __init__(self):
        self.C, self.R, self.H = map(int, input().split())
        self.box = [[[0 for col in range(self.C)] for row in range(self.R)] for height in range(self.H)]
        self.isVisit = [[[False for col in range(self.C)] for row in range(self.R)] for height in range(self.H)]
        self.queue = Queue()
        self.unripen = 0

        for h in range(self.H):
            for r in range(self.R):
                inptStr = list(map(int, input().split()))
                for c in range(self.C):
                    self.box[h][r][c] = inptStr[c]
                    if self.box[h][r][c] == 1:
                        self.queue.enqueue([h, r, c])
                        self.isVisit[h][r][c] = True
                    if self.box[h][r][c] == 0:
                        self.unripen += 1
    def doBFS(self):
        answer = 1
        while self.queue.getSize() > 0:
            curPos = self.queue.dequeue()
            h = curPos[0]
            r = curPos[1]
            c = curPos[2]
            answer  = self.box[h][r][c]

            if r > 0 and self.isVisit[h][r - 1][c] == False and self.box[h][r - 1][c] == 0:
                self.isVisit[h][r - 1][c] = True
                self.box[h][r - 1][c] = answer + 1
                self.queue.enqueue([h, r - 1, c])
            
            if r < self.R - 1 and self.isVisit[h][r + 1][c] == False and self.box[h][r + 1][c] == 0:
                self.isVisit[h][r + 1][c] = True
                self.box[h][r + 1][c] = answer + 1
                self.queue.enqueue([h, r + 1, c])

            if c > 0 and self.isVisit[h][r][c - 1] == False and self.box[h][r][c - 1] == 0:
                self.isVisit[h][r][c - 1] = True
                self.box[h][r][c - 1] = answer + 1
                self.queue.enqueue([h, r, c - 1])
            
            if c < self.C - 1 and self.isVisit[h][r][c + 1] == False and self.box[h][r][c + 1] == 0:
                self.isVisit[h][r][c + 1] = True
                self.box[h][r][c + 1] = answer + 1
                self.queue.enqueue([h, r, c + 1])

            if h > 0 and self.isVisit[h - 1][r][c] == False and self.box[h - 1][r][c] == 0:
                self.isVisit[h - 1][r][c] = True
                self.box[h - 1][r][c] = answer + 1
                self.queue.enqueue([h - 1, r, c])

            if h < self.H - 1 and self.isVisit[h + 1][r][c] == False and self.box[h + 1][r][c] == 0:
                self.isVisit[h + 1][r][c] = True
                self.box[h + 1][r][c] = answer + 1
                self.queue.enqueue([h + 1, r, c])
        
        if self.unripen == 0:
            print(answer - 1)   # answer start from 0
        else:
            print(-1)           # failed

bfs = BFS()
bfs.doBFS()