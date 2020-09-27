#include <stdio.h>
#include <stdlib.h>
#include <time.h>

//2nd Try -> Timeout failed

void quickSort(int leftIdx, int rightIdx, int * data);
int partition(int leftIdx, int rightIdx, int * data);
void swap(int* x, int* y);

int main(void){
    int size = 0;
    int* array = NULL;
    srand((unsigned int)time(NULL));

    scanf("%d", &size);
    array = (int*)malloc(sizeof(int) * size);
    for(int i = 0 ; i < size ; i++)
        scanf("%d", &array[i]);

    quickSort(0, size - 1, array);

    for(int i = 0 ; i < size ; i++)
        printf("%d\n", array[i]);
}

void quickSort(int leftIdx, int rightIdx, int * data){
    if(leftIdx < rightIdx){
        int pivotIdx = partition(leftIdx, rightIdx, data);
        quickSort(leftIdx, pivotIdx - 1, data);
        quickSort(pivotIdx + 1, rightIdx, data);
    }
}

int partition(int leftIdx, int rightIdx, int * data){
    int tempIdx = (rand() % (rightIdx - leftIdx + 1)) + leftIdx;
    if(tempIdx > leftIdx && tempIdx < rightIdx)
        swap(&data[leftIdx], &data[tempIdx]);
    
    int pivotItem = data[leftIdx];
    int lowIdx = leftIdx + 1;
    int highIdx = rightIdx;

    while(lowIdx <= highIdx){
        while(lowIdx < rightIdx && pivotItem >= data[lowIdx])
            lowIdx++;
        while(leftIdx < highIdx && pivotItem <= data[highIdx])
            highIdx--;
        if(lowIdx < highIdx)
            swap(&data[lowIdx], &data[highIdx]);
    }

    swap(&data[leftIdx], &data[highIdx]);
    return highIdx;
}

void swap(int* x, int* y){
    int temp = *x;
    *x = *y;
    *y = temp;
}