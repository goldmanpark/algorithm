# https://programmers.co.kr/learn/courses/30/lessons/12910

def solution(arr, divisor):
    answer = []
    for a in arr:
        if a % divisor == 0:
            answer.append(a)
    answer.sort()
    if len(answer) == 0:
        answer.append(-1)
    return answer