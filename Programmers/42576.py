# https://programmers.co.kr/learn/courses/30/lessons/42576

def solution(participant, completion):
    dic = {}
    for p in participant:
        if p in dic:
            dic[p] += 1
        else:
            dic[p] = int(1)
    
    for c in completion:
        if dic[c] > 1:
            dic[c] -= 1
        else:
            del dic[c]
    
    return list(dic.keys())[0]