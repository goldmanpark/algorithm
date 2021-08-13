# https://programmers.co.kr/learn/courses/30/lessons/42748

def solution(array, commands):
    answer = []
    for c in commands:
        i = c[0]
        j = c[1]
        k = c[2]
        temp = array[i-1:j]
        temp.sort()
        answer.append(temp[k-1])
        
    return answer