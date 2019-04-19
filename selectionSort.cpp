//////////////////////////////////////////////////////////////////////////////////
//HEADER FILES
/////////////////////////////////////////////////////////////////////////////////
#include <iostream>
#include <string>
#include <stdlib.h>
#include <vector>
#include <fstream>
#include <ctime>
#include <limits.h>
#include <math.h>
using namespace std;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Function Prototypes
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void displayList(vector<int>);							//displays the list
void exchange(vector<int>&, int, int);						//exchanges two items in the list											
unsigned long selectionSort(vector<int>&, int);						//performs the selection sort




//MAIN
int main(int argc, char * argv[])
{
	//variables
	vector<int> A;
	int input;
	int size = 0;
	unsigned long comps = 0;	
	string fileName;
	clock_t begin;
	clock_t end;
	double runTime = 0;



	if(argc <=1)	//no data to input
	{
		return 0;
	}


	//gets the filename from the argv[1]
	fileName = argv[1];
	ifstream infile(fileName);



	//gets the input
	while(infile >> input)
	{
		A.push_back(input);
		size++;
	}


	//gets start time
	begin = clock();

	//performs the quicksort, and gets the number of comparisons
	comps = selectionSort(A, size);

	//gets end time
	end = clock();


	//calculates the runtime
	runTime = double(end-begin) / (CLOCKS_PER_SEC/1000);

	cout << size << ", " << comps << ", " << runTime << endl;




	return 0;
}//END MAIN



/////////////////////////////////////////////////////////
//FUNCTION IMPLEMENTATIONS
/////////////////////////////////////////////////////////
void displayList(vector<int>A)
{
	for(int i = 0; i<((int)A.size()); i++)
	{
		cout << A.at(i) << endl;
	}


}//END DISPLAY


/*
void displayList(vector<int>A)
{
	for(int i = 0; i<((int)A.size()); i++)
	{
		cout << A.at(i) << endl;
	}


}//END DISPLAY
*/

//EXCHANGES THE VALUES at the given indices
void exchange(vector<int>& A, int index1, int index2)
{
	int temp = A[index1];
	A[index1] = A[index2];
	A[index2] = temp;


}//END exchange

int selectionSort(vector<int>& A, int size)
{

	int comps = 0;

	for(int i = 0; i < size-1; i++)
	{
		
		int smallest = i;

		for(int j = i+1; j < size; j++)
		{
			
			comps++;
			if(A[j] < A[smallest])
			{
				smallest = j;
			}
		}//end inner for loop

		if(smallest != i)
		{
			exchange(A, smallest, i);
		}

	}//end out for loop


	return comps;
}
