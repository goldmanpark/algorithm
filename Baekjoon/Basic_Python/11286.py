import sys

class Node:
    def __init__(self, x):
        self.absVal = abs(x)
        if x > 0:
            self.minusVal = 0
            self.plusVal = 1
        elif x < 0:
            self.minusVal = 1
            self.plusVal = 0
    def insert(self, x):
        if x > 0:
            self.plusVal += 1
        elif x < 0:
            self.minusVal += 1
    def get(self):
        if self.minusVal > 0:
            self.minusVal -= 1
            return -1 * self.absVal
        elif self.plusVal > 0:
            self.plusVal -= 1
            return self.absVal
    def isAvailable(self):
        if self.minusVal == 0  and self.plusVal == 0:
            return False
        else:
            return True

class Queue:    # for BFS
    queue = []
    def enqueue(self, x):
        self.queue.append(x)
    def dequeue(self):
        val = self.queue[0]
        del self.queue[0]
        return val   
    def getSize(self):
        return len(self.queue)

class AbsHeap:
    def __init__(self):
        self.heap = [0]
        self.absSet = set()
        self.size = 0   # 'size' also means last index of heap

    def searchIdxofX(self, x):    # return index of abs(x)
        q = Queue()         # queue of indices
        q.enqueue(1)
        absX = abs(x)
        while q.getSize() > 0:
            idx = q.dequeue()
            if self.heap[idx].absVal == absX:
                return idx
            if idx * 2 <= self.size and self.heap[idx * 2].absVal <= absX:
                q.enqueue(idx * 2)
            if idx * 2 + 1 <= self.size and self.heap[idx * 2 + 1].absVal <= absX:
                q.enqueue(idx * 2 + 1)        
        return -1   # cannot find

    def swap(self, a, b):
        temp = self.heap[a]
        self.heap[a] = self.heap[b]
        self.heap[b] = temp

    def Push(self, x):
        ''' if heap already has node of x, find it's index'''
        absX = abs(x)
        if absX in self.absSet:
            i = self.searchIdxofX(absX)
            if i != -1:
                self.heap[i].insert(x)
        else:
            node = Node(x)
            self.heap.append(node)
            self.absSet.add(absX)
            self.size += 1
            idx = self.size    # last Index
            while idx // 2 >= 1:
                parentIdx = idx // 2
                if self.heap[idx].absVal < self.heap[parentIdx].absVal:
                    self.swap(idx, parentIdx)
                    idx = parentIdx
                else:
                    break

    def Pop(self):
        if self.size == 0:
            print(0)
        else:
            val = self.heap[1].get()
            print(val)
            ''' if root node has no value'''
            if self.heap[1].isAvailable() == False:
                self.absSet.remove(abs(val))
                self.heap[1] = self.heap[self.size]
                del self.heap[self.size]
                self.size -= 1
                idx = 1   

                while idx * 2 <= self.size:
                    leftIdx = idx * 2   #left child index
                    rightIdx = leftIdx + 1   #right child index
                    if rightIdx > self.size or self.heap[leftIdx].absVal < self.heap[rightIdx].absVal:
                        if self.heap[leftIdx].absVal < self.heap[idx].absVal:
                            self.swap(leftIdx, idx)
                            idx = leftIdx
                        else:
                            break
                    else:
                        if self.heap[rightIdx].absVal < self.heap[idx].absVal:
                            self.swap(rightIdx, idx)
                            idx = rightIdx
                        else:
                            break

N = int(sys.stdin.readline())
absHeap = AbsHeap()
for i in range(N):
    inputVal = int(sys.stdin.readline())
    if inputVal == 0:
        absHeap.Pop()
    else:
        absHeap.Push(inputVal)