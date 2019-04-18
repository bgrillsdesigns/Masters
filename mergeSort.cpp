/////////////////////////////////////////////
//HEADER FILES
/////////////////////////////////////////////
#include <iostream>
#include <string>
#include <stdlib.h>
#include <vector>
#include <fstream>
#include <ctime>
#include <limits.h>
#include <math.h>
using namespace std;

///////////////////////////////////////////////////////////////////////////////////////////////////
//Function Prototypes
//////////////////////////////////////////////////////////////////////////////////////////////////
void DisplayList(vector<int>);					//displays the list
void exchange(vector<int>&, int, int);				//exchanges two items in the list
int merge(vector<int>&, int, int, int, int);			//returns number of comparisons
void mergeSort(vector<int>&, int, int, unsigned long&);



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
	mergeSort(A, 0, size, comps);
	end = clock();


	runTime = double(end-begin) / (CLOCKS_PER_SEC/1000);

	cout << size << ", " << comps << ", " << runTime << endl;


	return 0;

}//END MAIN





////////////////////////////////////////////////////////////////////////
//FUNCTION IMPLEMENTATIONS
///////////////////////////////////////////////////////////////////////

//PRINTS OUT ALL ELEMENTS IN THE LIST
void DisplayList(vector<int> A)
{
	for(int i = 0; i<((int)A.size()); i++)
	{
		cout << A.at(i) << endl;
	}

}//END DISPLAYLIST


//EXCHANGES THE ELEMENTS AT INDEX1 AND INDEX2
void exchange(vector<int>& A, int index1, int index2)
{
	int tempHolder = A[index1];
	A[index1] = A[index2];
	A[index2] = tempHolder;

}//END EXCHANGE




//MERGES THEM TOGETHER
int merge(vector<int>& A, int p, int m1, int m2, int r)
{
	int ret = 0;
	int size1 = m1-1;
	int size2 = m2-m1;
	int size3 = r-(m2-1);

	vector<int> leftList;
	vector<int> middleList;
	vector<int> rightList;

	for (int i = 0; i < size1; i++)
	{
		leftList.push_back(A[p+i]);
	}
	for (int j = 0; j < size2; j++)
	{
		middleList.push_back(A[m1+j]);
	}
	for (int k = 0; k < size3; k++)
	{
		rightList.push_back(A[m2+k]);
	}

	leftList.push_back(INT_MAX);
	middleList.push_back(INT_MAX);
	rightList.push_back(INT_MAX);

	
	int c1 = 0, c2 = 0, c3 = 0;




	for(int i = p; i <= r; i++)
	{
		ret++;
		if(leftList[c1] <= middleList[c2])
		{
			ret++;
			if(leftList[c1] <= rightList[c3])
			{
				A[i] = leftList[c1];
				c1++;
			}
			else
			{
				A[i] = rightList[c3];
				c3++;
			}
		}
		else
		{
			ret++;
			if(middleList[c2] <= rightList[c3])
			{
				A[i] = middleList[c2];
				c2++;
			}
			else
			{
				A[i] = rightList[c3];
				c3++;
			}
		}
	}


	return ret;
}//END MERGE


/*

void mergeSort(vector<int>& A, int p, int r, unsigned long& comps)
{
	if((r-p) >= 2)
	{
		//Get 1/3 point
		int m1 = p + ((r-p)/3);
		//Get 2/3 point
		int m2 = p + ((2*(r-p))/3);
		//Separately sort and merge 3 ways.
		mergeSort(A, p, m1, comps);
		mergeSort(A, m1, m2, comps);
		mergeSort(A, m2, r, comps);
		comps += merge(A, p, m1, m2, r);
	}
	else if (r-p == 1 && A[p] > A[r]) 
	{
		exchange(A, p, r);
	}


}//END MERGESORT

//Commenting out the end of the file (No closing multiline symbol)