#include <stdio.h>
#include <stdlib.h>

void quickSort(int leftIdx, int rightIdx, int** data);
int partition(int leftIdx, int rightIdx, int** data);
void swap(int i, int j, int** data);
int compare(int pivotIdx, int targetIdx, int** data);

int main(void){
    int size = 0;
    int** list = NULL;

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
    int tempIdx = (rightIdx + leftIdx) / 2;
    if(tempIdx > leftIdx && tempIdx < rightIdx)
        swap(leftIdx, tempIdx, data);

    int lowIdx = leftIdx + 1;
    int highIdx = rightIdx;

    while(lowIdx <= highIdx){   //leftIdx means pivotIdx
        while(lowIdx <= highIdx && compare(leftIdx, lowIdx, data) > 0)  //pivotItem > lowItem
            lowIdx++;
        while(lowIdx <= highIdx && compare(leftIdx, highIdx, data) == 0) //pivotItem <= highItem
            highIdx--;
        if(lowIdx <= highIdx)
            swap(lowIdx, highIdx, data);
    }
    swap(leftIdx, highIdx, data);
    return highIdx;
}

void swap(int i, int j, int** data){
    int* temp = data[i];
    data[i] = data[j];
    data[j] = temp;
}

int compare(int pivotIdx, int targetIdx, int** data){
    //if pivotItem > targetItem then return 1
    //else return 0
    if(data[pivotIdx][1] > data[targetIdx][1])
        return 1;
    else if(data[pivotIdx][1] < data[targetIdx][1])
        return 0;
    else if(data[pivotIdx][1] == data[targetIdx][1])
    {
        if(data[pivotIdx][0] > data[targetIdx][0])
            return 1;
        else if(data[pivotIdx][0] <= data[targetIdx][0])
            return 0;
    }
}