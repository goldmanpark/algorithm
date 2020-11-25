import sys

#failed

class MaxHeap:
    heap = [0]

    def Swap(self, a, b):
        temp = self.heap[a]
        self.heap[a] = self.heap[b]
        self.heap[b] = temp
    
    def Push(self, x):
        self.heap.append(x)

        ''' compare with parent node '''
        idx = len(self.heap) - 1
        while idx // 2 >= 1:
            if self.heap[idx] > self.heap[idx // 2]:
                self.Swap(idx, idx // 2)
                idx = idx // 2
            else:
                break

    def Pop(self):
        count = len(self.heap) - 1
        if count == 0:
            print(0)
        else:
            print(self.heap[1])

            ''' compare with child node '''
            self.heap[1] = self.heap[count]
            del self.heap[count]
            idx = 1
            maxIdx = len(self.heap) - 1
            while idx * 2 + 1 <= maxIdx:
                a = idx * 2   #left child
                b = a + 1   #right child
                if self.heap[a] > self.heap[b]:
                    if self.heap[a] > self.heap[idx]:
                        self.Swap(a, idx)
                        idx = a
                    else:
                        break
                else:
                    if self.heap[b] > self.heap[idx]:
                        self.Swap(b, idx)
                        idx = b
                    else:
                        break

N = int(sys.stdin.readline())
maxHeap = MaxHeap()
for i in range(N):
    inputVal = int(sys.stdin.readline())
    if inputVal == 0:
        maxHeap.Pop()
    else:
        maxHeap.Push(inputVal)