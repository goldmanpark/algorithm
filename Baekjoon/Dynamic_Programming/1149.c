#include <stdio.h>
#include <stdlib.h>
#include <string.h>
/*
    C# solution has failed(timeout).
    
    When Number of houses is N,
    then min(N) = min(N-1) + (minimum value of index N, satisfying the condition of N-1)

    if a color of house i is Red,
    then memo[i, R] = min(memo[i - 1, G], memo[i - 1, B]) + cost[i, R]
    It's necessary to calculate memo[i, R], memo[i, G], memo[i, B]
    because color costs of a specific index can be all same
*/
#ifndef MIN
#define MIN(a, b)  (((a) < (b)) ? (a) : (b))
#endif

int main(void)
{
    int N = 0;
    int ** memo = NULL;
    int ** costList = NULL;

    //initial setting
    scanf("%d", &N);
    memo = (int**)malloc(sizeof(int*) * N);
    costList = (int**)malloc(sizeof(int*) * N);
    
    for(int i = 0 ; i < N ; i++){
        memo[i] = (int*) malloc(sizeof(int) * 3);
        costList[i] = (int*) malloc(sizeof(int) * 3);
        memset(memo[i], 0, 3 * 4);
    }

    for(int i = 0 ; i < N ; i++){
        scanf("%d", &costList[i][0]);
        scanf("%d", &costList[i][1]);
        scanf("%d", &costList[i][2]);
    }
    
    //tabulation
    memo[0][0] = costList[0][0];
    memo[0][1] = costList[0][1];
    memo[0][2] = costList[0][2];
        
    //Dynamic Programming
    for(int i = 1 ; i <= N - 1 ; i++){
        memo[i][0] = MIN(memo[i - 1][1], memo[i - 1][2]) + costList[i][0];
        memo[i][1] = MIN(memo[i - 1][0], memo[i - 1][2]) + costList[i][1];
        memo[i][2] = MIN(memo[i - 1][0], memo[i - 1][1]) + costList[i][2];
    }

    //get answer
    printf("%d\n", MIN(MIN(memo[N - 1][0], memo[N - 1][1]), memo[N - 1][2]));
}