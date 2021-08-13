# https://programmers.co.kr/learn/courses/30/lessons/12917

def solution(s):
    temp = list(s)
    temp.sort(reverse=True)
    return ''.join(temp)