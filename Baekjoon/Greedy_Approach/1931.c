#include <stdio.h>
#include <stdlib.h>
#include <time.h>

//2nd Try -> Timeout Failed

void quickSort(int leftIdx, int rightIdx, int** data);
int partition(int leftIdx, int rightIdx, int** data);
void swap(int i, int j, int** data);

int main(void){
    int size = 0;
    int** list = NULL;
    srand((unsigned int)time(NULL));

    scanf("%d", &size);
    list = (int**)malloc(sizeof(int*) * size);
    for(int i = 0 ; i < size ; i++)
        list[i] = (int*) malloc(sizeof(char) * 2);
	
    for(int i = 0 ; i < size ; i++){
        int temp = 0;
        scanf("%d", &temp);
        list[i][0] = temp;
        scanf("%d", &temp);
        list[i][1] = temp;
    }
    
    quickSort(0, size - 1, list);

    int answer = 1;
    int lastIdx = 0;
    for(int i = 1 ; i < size ; i++){
        if(list[lastIdx][1] <= list[i][0])
        {
            answer++;
            lastIdx = i;
        }
    }
    printf("%d\n", answer);
}

void quickSort(int leftIdx, int rightIdx, int** data){
    if(leftIdx < rightIdx){
        int pivotIdx = partition(leftIdx, rightIdx, data);
        quickSort(leftIdx, pivotIdx - 1, data);
        quickSort(pivotIdx + 1, rightIdx, data);
    }
}

int partition(int leftIdx, int rightIdx, int** data){    
    int tempIdx = (rand() % rightIdx - leftIdx + 1) + leftIdx;
    if(tempIdx > leftIdx && tempIdx < rightIdx)
        swap(leftIdx, tempIdx, data);

    int pivotItem = data[leftIdx][1];
    int lowIdx = leftIdx + 1;
    int highIdx = rightIdx;

    while(lowIdx <= highIdx){
        while(pivotItem >= data[lowIdx][1] && lowIdx < rightIdx)
            lowIdx++;
        while(pivotItem <= data[highIdx][1] && leftIdx < highIdx)
            highIdx--;
        if(lowIdx <= highIdx)
            swap(lowIdx, highIdx, data);
    }
    swap(leftIdx, lowIdx, data);
    return highIdx;
}

void swap(int i, int j, int** data){
    int* temp = data[i];
    data[i] = data[j];
    data[j] = temp;
}