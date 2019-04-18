////////////////////////////////////////////////////////////////////////
//HEADER FILES
///////////////////////////////////////////////////////////////////////
#include <iostream>
#include <string>
#include <stdlib.h>
#include <vector>
#include <fstream>
#include <ctime>
#include <limits.h>
#include <math.h>
using namespace std;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Function Prototypes
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void displayList(vector<int>);							//displays the list
void exchange(vector<int>&, int, int);						//exchanges two items in the list
int partition(vector<int>&, int, int, unsigned long&);					//returns number of comparisons
void quickSort(vector<int>&, int, int, unsigned long&);


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

	fileName = argv[1];
	ifstream infile(fileName);



	//gets the input
	while(infile >> input)
	{
		A.push_back(input);
		size++;
	}


	begin = clock();
	quickSort(A, 0, size, comps);
	end = clock();


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


//EXCHANGES THE VALUES at the given indices
void exchange(vector<int>& A, int index1, int index2)
{
	int temp = A[index1];
	A[index1] = A[index2];
	A[index2] = temp;

}//END exchange


//PARTITONS A
int partition(vector<int>& A, int p, int r, unsigned long& comps)
{
	//SETS THE FIRST ELEMENT TO THE PIVOT
	int pivot = A[p];
	int i = p+1;
	for(int j = i; j <= r; j++)
	{
		comps++;
		if(A[j] <= pivot)
		{
			exchange(A, i, j);
			i++;
		}
	}
	

	exchange(A, i-1, p);
	return i-1;


}//END PARTITION


//Quicksort for testing
/*
void quickSort(vector<int>& A, int p, int r, unsigned long& comps)
{
	if(p < r)
	{
		int q = partition(A, p, r, comps);
		quickSort(A, p, q-1, comps);
		quickSort(A, q+1, r, comps);
	}


}


*/



//PERFORMS THE QUICKSORT
void quickSort(vector<int>& A, int p, int r, unsigned long& comps)
{
	if(p < r)
	{
		int q = partition(A, p, r, comps);
		quickSort(A, p, q-1, comps);
		quickSort(A, q+1, r, comps);
	}



}//END QUICKSORT

