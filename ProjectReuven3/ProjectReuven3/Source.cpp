#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>
#include <string.h>

typedef struct node
{
	int key;
	struct node *next;
}NODE;

//פונקציית עזר הופסה לסוף
void addToLast(int data, NODE** head)
{
	NODE* new_node = (NODE*)malloc(sizeof(struct node));

	NODE *last = *head;

	new_node->key = data;
	new_node->next = NULL;

	if (*head == NULL)
	{
		*head = new_node;
		return;
	}

	while (last->next != NULL)
		last = last->next;

	last->next = new_node;
	return;
}

//הדפסת הLIST
void printList(NODE* head) 
{
	NODE* temp = head;

	if (head != NULL) 
	{
		printf("\nThe list contains: ");
		while (temp)
		{
			printf("%d ", temp->key);
			temp = temp->next;
		}
	}

	else 
		printf("\nThe list is empty.");
}

// מימוש הפונקציות ולקיחת שרשרת ומסדרת אותה קודם אין זוגי ואז זוגי 
NODE *Reorder(NODE *head)
{
	NODE *temp = head, *zogi = NULL, * newNode = NULL;

	if (head != NULL)
	{
		while (temp)
		{
			if (temp->key % 2 != 0)
			{
				addToLast(temp->key, &newNode);
			}

			else
				addToLast(temp->key, &zogi);

			temp = temp->next;
		}

		while (zogi)
		{
			addToLast(zogi->key, &newNode);
			zogi = zogi->next;
		}
	}

	else
		printf("\nThe list is empty.");

	return newNode;
}

void main()
{
	NODE *head = NULL;

	addToLast(4, &head);
	addToLast(1, &head);
	addToLast(6, &head);
	addToLast(8, &head);
	addToLast(5, &head);
	addToLast(3, &head);
	addToLast(2, &head);

	printList(head);

	NODE *newNode = Reorder(head);
	printList(newNode);
}