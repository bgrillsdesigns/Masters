#include <iostream>
#include <string.h>

int FindN(){ //this function finds the unknown end value for our array to use for guessing
	bool found = true;
	int power = 10;
	std::string hL;

	while(found){
		std::cout << "Is your number higher or lower than : " << power << "?" << std::endl;
		std::cin >> hL;

		if(hL == "lower"){
			return power;
		}
		else{
			//power = power * power;
			power = power * 10;
			found = false;
		}
	}
}

int Check(int nArray[], int guess){
	std::string hL;

	std::cout << "Is your number higher, lower or exactly: " << nArray[guess] << "?" << std::endl;
	std::cin >> hL;

	if(hL == "higher")
		return 1;
	else if(hL == "lower")
		return -1;
	else
		return 0;

}
void Guess(int nArray[], int n){
	int result;
	int guess = n / 2;
	int low = 0;
	int high = n;
	result = Check(nArray, guess - 1);

	
	while(result != 0){

		if(result == -1){
			high = guess - 1;
			guess = high / 2;
			result = Check(nArray, guess);
		}
		else{
			low = guess + 1;
			guess =((high - low) / 2) + guess;
			result = Check(nArray, guess);
		}

	}

	if(result == 0)
		std::cout << "Yay! I win, thanks for playing!" << std::endl;
}

int main(){

	//This program is designed in order to test a comment parser that will
	//detect and remove commented out code and place it in a quarentiening document

	/*The goal of this program should be reached in both types of comments in C++
	the standard double slash and the block commenting style*/
	int n;

	std::cout << "This is a guessing game, lets have some fun!" << std::endl;
	std::cout << "I want you to think of a number, I am going " << std::endl;
	std::cout << "to guess what your number is. it does not   " << std::endl;
	std::cout << "matter how large it is; just make sure that " << std::endl;
	std::cout << "it is a positive number!" << std::endl;

	n = FindN();
	int nArray [n];

	/*Lets build the array (false code follows)
	int i = 1;
	int j = 0;
	while(n != 0){
		nArray[j] = i;
		i++;
		j++;
		n--;
	}*/

	/*Why not build the array in its own function?
	nArray = BuildArray(n);
	*/

	for(int i = 0; i <= n; i++){
		nArray[i] = (i+1);
	}

	Guess(nArray, n);
	return 0;
}