#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>
#include <string.h>

//פונקציה שמדפיסה את המערך שמקבלת
void printArr(int arr[][4])
{
	printf("\nAll class:\n\n");
	for (int i = 0; i < 30; i++)
	{
		printf("%d) ", i + 1);
		for (int j = 0; j < 4; j++)
			printf("%d ", arr[i][j]);
		printf("\n\n");
	}
}

//פונקציית מחזירה את המקסימום הבדל במערך שמקבלים
int findMaxDif(int data[][4])
{
	int curr;
	int maxDif = data[0][0] - data[0][1];
	for (int i = 1; i < 30; i++)
	{
		curr = data[i][0] - data[i][1];
		if (maxDif < curr)
			maxDif = curr;
	}
	return maxDif;
}

//פונקציה שמחזירה את המקסימום הבדל בכל הכיתות ומדפיסה אותם
int Max_Grades_dif(int data[][4])
{
	int max = findMaxDif(data);
	printf("\nClass with max difference between max grade and minimum:\n\n");

	for (int i = 0; i < 30; i++)
	{
		if (max == data[i][0] - data[i][1])
		{
			printf("%d) ", i + 1);
			for (int j = 0; j < 4; j++)
				printf("%d ", data[i][j]);
			printf("\n\n");
		}
	}
	return max;
}
// מקבל פרמטר מספר לשכבה ומחזירה את סכום הציונים בשכבה הספציםית
float sumGradesLevel(int data[][4], int level)
{
	float sum = 0;

	for (int i = (level - 1) * 10; i < level * 10; i++)
		sum += data[i][2];

	return sum / 10;
}

// מחזיר את המקסימום ממוצע השכבתי בין כל השכבות
float Max_Avg(int data[][4])
{
	float maxYood = sumGradesLevel(data, 1);
	float maxYoodA = sumGradesLevel(data, 2);
	float maxYoodB = sumGradesLevel(data, 3);

	if (maxYood > maxYoodA && maxYood > maxYoodB) 
	{
		printf("\n\nThe level with highest average: 0");
		return maxYood;
	}

	if (maxYoodA > maxYood && maxYoodA > maxYoodB)
	{
		printf("\n\nThe level with highest average: 1");
		return maxYoodA;
	}
	printf("\n\nThe level with highest average: 2");
	return maxYoodB;
}

//מימוש הפונקציות
void main()
{
	srand(time(0));
	
	int data[30][4] = { 0 };

	for (int i = 0; i < 30; i++)
		for (int j = 0; j < 4; j++)
			switch (j)
			{
			case(0):
				data[i][j] = (rand() % (100 - 90 + 1)) + 90;
				break;

			case(1):
				data[i][j] = (rand() % (65 - 45 + 1)) + 45;
				break;

			case(2):
				data[i][j] = (rand() % (90 - 75 + 1)) + 75;
				break;

			default:
				data[i][j] = (rand() % (30 - 24 + 1)) + 24;
				break;
			}

	printArr(data);
	Max_Grades_dif(data);
	Max_Avg(data);
}