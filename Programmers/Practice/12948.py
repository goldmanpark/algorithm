# https://programmers.co.kr/learn/courses/30/lessons/12948

def solution(phone_number):
    length = len(phone_number)
    return ('*' * (length - 4)) + phone_number[length - 4 : length]