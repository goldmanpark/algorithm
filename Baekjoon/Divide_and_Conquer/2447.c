#include <stdio.h>
#include <stdlib.h>

static int size = 0;
static char** square = NULL;
void Draw(int len, int x, int y, char ch);

int main(void) {
	scanf("%d", &size);
	square = (char**) malloc(sizeof(char*) * size);

	for(int i = 0 ; i < size ; i++){
	  square[i] = (char*) malloc(sizeof(char) * size);
	}

	Draw(size, 0, 0, '*');

	for(int i = 0 ; i < size ; i++){
		for(int j = 0 ; j < size ; j++){
			printf("%c", square[i][j]);
		}
		printf("\n");
	}
}

void Draw(int len, int x, int y, char ch)
{
	if(len < 3)
		square[x][y] = ch;
	else{
		/*
			square form:
			0 1 2
			3 4 5
			6 7 8
		*/
		int newLen = len / 3;
		int newLen2 = newLen + newLen;
		Draw(newLen, x, y, ch);                     // 0
		Draw(newLen, x, y + newLen, ch);            // 1
		Draw(newLen, x, y + newLen2, ch);           // 2

		Draw(newLen, x + newLen, y, ch);            // 3
		Draw(newLen, x + newLen, y + newLen, ' ');  // 4
		Draw(newLen, x + newLen, y + newLen2, ch);  // 5

		Draw(newLen, x + newLen2, y, ch);           // 6
		Draw(newLen, x + newLen2, y + newLen, ch);  // 7
		Draw(newLen, x + newLen2, y + newLen2, ch); // 8
	}
}