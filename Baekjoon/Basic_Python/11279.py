import sys

class MaxHeap:
    heap = [0]

    def Swap(self, a, b):
        temp = self.heap[a]
        self.heap[a] = self.heap[b]
        self.heap[b] = temp
    
    def Push(self, x):
        self.heap.append(x)

        ''' compare with parent node (from leap to root) '''
        idx = len(self.heap) - 1 # current Index
        while idx // 2 >= 1:
            parentIdx = idx // 2
            if self.heap[idx] > self.heap[parentIdx]:
                self.Swap(idx, parentIdx)
                idx = parentIdx
            else:
                break

    def Pop(self):
        count = len(self.heap) - 1
        if count == 0:
            print(0)
        else:
            print(self.heap[1])

            ''' compare with child node (from root to leap) '''
            self.heap[1] = self.heap[count]
            del self.heap[count]
            idx = 1
            maxIdx = count - 1

            while idx * 2 <= maxIdx:
                leftIdx = idx * 2   #left child index
                rightIdx = leftIdx + 1   #right child index

                if rightIdx > maxIdx or self.heap[leftIdx] > self.heap[rightIdx]:
                    if self.heap[leftIdx] > self.heap[idx]:
                        self.Swap(leftIdx, idx)
                        idx = leftIdx
                    else:
                        break
                else:
                    if self.heap[rightIdx] > self.heap[idx]:
                        self.Swap(rightIdx, idx)
                        idx = rightIdx
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