#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>
#include <string.h>

const int N = 7;

//פונקציית עזר שמדפיסה את המטריצה
void printMatriza(int mat[][N])
{
	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++)
			printf("%d ", mat[i][j]);
		printf("\n");
	}
	printf("\n");
}

//פונקציית עזר שמדפיסה את את השורה האחרון במטריצה
void printArrHorizontal(int mat[N])
{
	for (int i = 0; i < N; i++)
		printf("%d ", mat[i]);
	printf("\n\n");
}

//פונקציית עזר שמדפיסה את את הטור האחרון במטריצה
void printArrVertical(int mat[][N])
{
	for (int i = 0; i < N; i++)
		printf("%d ", mat[i][N-1]);
	printf("\n\n");
}

//פונקציית חיפוש בינארי אשר מחפשת בטור האחרון את המופע הכי עליון של 1
//פונקצייה מחפשת ב (log(n))
int binarySearchVertical(int arr[][N], int l, int r)
{
	int mid = l + (r - l) / 2;

	if ((arr[mid][N - 1] && mid == 0) || (arr[mid][N - 1] && !arr[mid - 1][N - 1]))
		return mid;

	if (arr[mid][N - 1])
		return binarySearchVertical(arr, l, mid - 1);

	return binarySearchVertical(arr, mid + 1, r);
}

//פונקציית חיפוש בינארי אשר מחפשת בשורה האחרונה את המופע הכי שמאלי של 1
//פונקצייה מחפשת ב (log(n))
int binarySearch(int arr[], int l, int r)
{
	int mid = l + (r - l) / 2;

	if ((arr[mid] && mid == 0) || (arr[mid] && !arr[mid - 1]))
		return mid;

	if (arr[mid])
		return binarySearch(arr, l, mid - 1);

	return binarySearch(arr, mid + 1, r);
}

//פונקצייה ראשית שקוראת לחיפושים הבינארים ומעדכנת את המשתנים שנדרשו בשאלה
//בגלל שנתון שהמלבן המינימלי הוא 1 על 1 צריך לחפש בשורה והטור האחרונים את המופעים העליונים והשמאלים ביותר
//מעדכנים את הנתונים בהתאם
void getUpperLeft(int mat[][N], int n, int &row, int &col)
{

	int resultV = binarySearchVertical(mat, 0, n - 1);

	int resultH = binarySearch(mat[n - 1], 0, n - 1);

	row = resultV;
	col = resultH;
}

void main()
{
	int row, col;
	int mat[N][N] = { 0 };

	for (int i = 3; i < N; i++)
		for (int j = 4; j < N; j++)
			mat[i][j] = 1;

	printMatriza(mat);

	getUpperLeft(mat, N, row, col);

	printArrVertical(mat);
	printf("Row is: %d\n\n ", row);

	printArrHorizontal(mat[N - 1]);
	printf("Col is: %d\n\n ", col);
}