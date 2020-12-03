import sys
# BFS
class Queue:
    queue = []
    def enqueue(self, x):
        self.queue.append(x)
    def dequeue(self):
        val = self.queue[0]
        del self.queue[0]
        return val   
    def getSize(self):
        return len(self.queue)

val = sys.stdin.readline().split()
S = int(val[0]) # Start
D = int(val[1]) # Destination
PQ = Queue()    # Parent Queue(queue of upper depth nodes)
CQ = Queue()    # Child Queue(queue of lower depth nodes)
V = set()       # Visited position set
depth = 0       # depth = second(answer we want)

CQ.enqueue(S)
V.add(S)
while CQ.getSize() > 0:
    PQ.queue = CQ.queue
    CQ.queue = []
    depth += 1

    while PQ.getSize() > 0:     # make child queue until parent queue is empty
        currPos = PQ.dequeue()  # current position
        if currPos == D:        # finished
            CQ.queue = []
            depth -= 1
            break
        x = currPos * 2
        y = currPos + 1
        z = currPos - 1
        if x <= 100000 and x not in V:
            CQ.enqueue(currPos * 2)
            V.add(x)
        if y <= 100000 and y not in V:
            CQ.enqueue(currPos + 1)
            V.add(y)
        if z >= 0 and z not in V:
            CQ.enqueue(currPos - 1)
            V.add(z)

print(depth)