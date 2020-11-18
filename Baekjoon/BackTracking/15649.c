#include <stdio.h>
#include <stdlib.h>

static int N, M;
void backTrack(int* list, int num, int currHeight);

int main(void)
{
    scanf("%d", &N);
    scanf("%d", &M);
    int* list = (int*)malloc(sizeof(int) * (M + 1));

    backTrack(list, 0, 0);
}

void backTrack(int* list, int num, int currHeight)
{
    list[currHeight] = num;
    if(currHeight == M){
        for(int i = 1 ; i <= M ; i++)
            printf("%d ", list[i]);
        printf("\n");
    }
    else{
        for(int i = 1 ; i <= N ; i++){
            int flag = 1;
            for(int j = 1 ; j <= currHeight ; j++){
                if(list[j] == i){
                    flag = 0;
                    break;
                }
            }
            if(flag == 0)   //if i is already in list, skip backTracking.
                continue;
            else
                backTrack(list, i, currHeight + 1);
        }                    
    }
    list[currHeight] = 0;
}