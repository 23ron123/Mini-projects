#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>
#include <string.h>

//פונקציה שמחזירה את הקוד בטקסט שמקבלים
// הפםונקציה מחזירה את הקוד
char* findCode(char *text)
{
	int sizeCode = 0;
	char firstChar = *text++;
	char *code = NULL;

	while (*text != firstChar)
	{
		code = (char*)realloc(code, sizeof(char)*++sizeCode);
		code[sizeCode - 1] = *text++;
	}

	code = (char*)realloc(code, sizeof(char)*++sizeCode);
	code[sizeCode - 1] = '\0';
	return code;
}

//פונקציה שמדפיסה את ההודעה לאחר שימוש בקוד בלי הקוד בהתחלה
void PrintDecoded(char *text, char *str2insert)
{
	char *code = findCode(text);
	int currPos = strlen(code) + 2;
	char *result = NULL;
	int position, i;

	for (i = 0; i < currPos; i++)
		text++;

	
	result = strstr(text, code);
	position = result - text;
	while (result)
	{
		for (i = 0; i < position; i++)
		{
			printf("%c", text[0]);
			text++;
		}
		printf("%s", str2insert);

		for (i = 0; i < strlen(code); i++)
			text++;

		result = strstr(text, code);
		position = result - text;
	}

	while (*text != '\0')
	{
		printf("%c", text[0]);
		text++;
	}
	
}

//מימוש הפונקציוצת
void main()
{
	char str2insert[] = "ronaldo";
	char text[] = "#12#12, how are you 12? do yo feel good 12?";
	PrintDecoded(text, str2insert);
}