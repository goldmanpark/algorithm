#include <stdio.h>
#include <stdlib.h>

static int ** array;
void Fibonacci(int x);

int main(void){
    int size = 0;
    scanf("%d", &size);

    for(int i = 0 ; i < size ; i++){
        int temp = 0;
        scanf("%d", &temp);
        array = (int**)malloc(sizeof(int*) * (temp + 2));
        for(int i = 0 ; i < temp + 2 ; i++){
            array[i] = (int*) malloc(sizeof(int) * 2);
            array[i][0] = 0;    // array[x][0] means count of 0 for Fibonacci(x)
            array[i][1] = 0;    // array[x][1] means count of 1 for Fibonacci(x)
        }
        array[0][0] = 1;    // When call Fibonacci(0), return 1 for count of 0
        array[1][1] = 1;    // When call Fibonacci(1), return 1 for count of 1

        Fibonacci(temp);
        printf("%d %d\n", array[temp][0], array[temp][1]);
    }
}

void Fibonacci(int x){
    if(x == 0 || x == 1)
        return;
    else if(array[x][0] != 0 || array[x][1] != 0)
        return;
    else{
        Fibonacci(x - 1);
        Fibonacci(x - 2);
        array[x][0] = array[x - 1][0] + array[x - 2][0];
        array[x][1] = array[x - 1][1] + array[x - 2][1];
    }        
}