# https://programmers.co.kr/learn/courses/30/lessons/42840
def solution(answers):
    arr1 = [1, 2, 3, 4, 5]
    arr2 = [2, 1, 2, 3, 2, 4, 2, 5]
    arr3 = [3, 3, 1, 1, 2, 2, 4, 4, 5, 5]
    ans = [0, 0, 0]
    
    idx = 0
    for x in answers:
        if arr1[idx % 5] == x:
            ans[0] += 1
        if arr2[idx % 8] == x:
            ans[1] += 1
        if arr3[idx % 10] == x:
            ans[2] += 1
        idx += 1

    answer = []
    m = max(ans)
    for i in range(0, 3):
        if ans[i] == m:
            answer.append(i + 1)
            
    answer.sort()
    return answer