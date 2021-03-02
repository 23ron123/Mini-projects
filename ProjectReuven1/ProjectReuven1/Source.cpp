#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>
#include <string.h>

#define MSIZE 10
#define VERTICAL 0
#define HORIZONTAL 1
#define SHIP '*'
#define EMPTY '.'
#define ERROR '^'

//הגדרת משתנה גלוגבלי מטריצה לשימוש קיר ביטחון
char matriza[MSIZE + 2][MSIZE + 2];

//פונקציית עזר אשר מדפיסה את המערך של המשחק 
void printArr(char board[MSIZE][MSIZE])
{
	for (int i = 0; i < MSIZE; i++)
	{
		for (int j = 0; j < MSIZE; j++)
			printf(" %c ", board[i][j]);
		printf("\n");
	}
	printf("\n");
}

//פונקציית עזר אשר מדפיסה את הקיר ביטחון של המערך
void printArrMatriza()
{
	for (int i = 0; i < MSIZE + 2; i++)
	{
		for (int j = 0; j < MSIZE + 2; j++)
			printf(" %c ", matriza[i][j]);
		printf("\n");
	}
	printf("\n");
}

//פונקציית עזר שבודקת מסביב לנקודה בקיר ביטחון אם הכל פנוי
//הפונקציה בודקת אם אין סירה מסביב או יוצאת מהגבולות
//פונקצייה מחזירה 1  אם פנוי ו0 אם לא
int checkAround(int row, int col)
{
	if (matriza[row - 1][col] == SHIP || matriza[row][col] == ERROR)
		return 0;

	if (matriza[row - 1][col + 1] == SHIP || matriza[row][col] == ERROR)
		return 0;

	if (matriza[row][col + 1] == SHIP || matriza[row][col] == ERROR)
		return 0;

	if (matriza[row + 1][col + 1] == SHIP || matriza[row][col] == ERROR)
		return 0;

	if (matriza[row + 1][col] == SHIP || matriza[row][col] == ERROR)
		return 0;

	if (matriza[row + 1][col - 1] == SHIP || matriza[row][col] == ERROR)
		return 0;

	if (matriza[row][col - 1] == SHIP || matriza[row][col] == ERROR)
		return 0;

	if (matriza[row - 1][col - 1] == SHIP || matriza[row][col] == ERROR)
		return 0;

	return 1;
}

//פונקציה ראשית אשר משתמשת בפונקציות עזר ובודקת אם ניתן להוסיף ספינה לפי ההגדרות
//אם אין מסביב סירה או אינו יוצא מהגבולות
//פונקצייה מחזירה 1  אם אפשר ו0 אם לא
int isAvailable(char board[MSIZE][MSIZE], int ship_size, int row, int col, int dir)
{
	int tRow = row;
	int tCol = col;

	if (dir == VERTICAL)
	{
		for (int i = 0; i < ship_size; i++)
		{
			if (!checkAround(tRow + 1, tCol + 1))
				return 0;

			tRow++;
		}
	}

	else
	{
		for (int i = 0; i < ship_size; i++)
		{
			if (!checkAround(tRow + 1, tCol + 1))
				return 0;

			tCol++;
		}
	}

	return 1;
}

//פונקציית עזר אשר בונה את הספינה במטריצה ובמערך הרגיל
void buildShip(char board[MSIZE][MSIZE], int ship_size, int row, int col, int dir)
{
	int tRow = row;
	int tCol = col;

	for (int i = 0; i < ship_size; i++)
	{
		if (dir == VERTICAL)
		{
			board[tRow][tCol] = SHIP;
			matriza[tRow + 1][tCol + 1] = SHIP;

			tRow++;
		}

		else
		{
			board[tRow][tCol] = SHIP;
			matriza[tRow + 1][tCol + 1] = SHIP;

			tCol++;
		}
	}
}

void main()
{
	char board[MSIZE][MSIZE];

	//אתחול המערך במקומות EMPTY
	for (int i = 0; i < MSIZE; i++)
		for (int j = 0; j < MSIZE; j++)
			board[i][j] = EMPTY;

	//אתחול המטריצה  במקומות EMPTY וגם ERROR
	for (int i = 0; i < MSIZE + 2; i++)
		for (int j = 0; j < MSIZE + 2; j++)
		{
			if (!i || !j || i == MSIZE + 1 || j == MSIZE + 1)
				matriza[i][j] = ERROR;

			else
				matriza[i][j] = EMPTY;
		}

	printArr(board);

	//אתחול משתנים
	int shilp_size = 0, row = 0, col = 0, dir = 0;
	
	while (1)
	{
		//הכנסת משתנים
		printf("Enter ship size(1-4): ");
		scanf("%d", &shilp_size);
		printf("\n");
		if (shilp_size > 4 || shilp_size < 1)
		{
			printf("wrong input\n\n");
			continue;
		}

		printf("Enter row index(0-%d): ", MSIZE-1);
		scanf("%d", &row);
		printf("\n");
		if (row > 9 || row < 0)
		{
			printf("wrong input\n\n");
			continue;
		}

		printf("Enter col index(0-%d): ", MSIZE - 1);
		scanf("%d", &col);
		printf("\n");
		if (col > 9 || col < 0)
		{
			printf("wrong input\n\n");
			continue;
		}

		printf("Enter direction(vertical = 0, horizontal = 1): ");
		scanf("%d", &dir);
		printf("\n");
		if (!(dir == 1 || dir == 0))
		{
			printf("wrong input\n");
			printf("\n");
			continue;
		}
		//סיום הכנסת משתנים

		//קריאה לפונקציה הראשית ובנייה של של הספינות בהתאם
		if (isAvailable(board, shilp_size, row, col, dir))
		{
			buildShip(board, shilp_size, row, col, dir);
			printArr(board);
		}

		else
			printf("wrong\n");

		printf("\n");
	}
}