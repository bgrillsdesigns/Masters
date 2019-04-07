#Author: Blake Grills
#This program is being used to analyze c-lang code 
#in order to find quarentine and then rebuild a program
#of all commented out codes

import sys

#infile = open(sys.argv[-1], "r")
inFileR = open("TestingProgram.cpp", "r")
oFile = open("CleanedProgram.cpp", "w")
qFile = open("quarentine.md", "w")

def CheckForComments(inFileR, qFile, oFile) :
    lowLine = 0
    highLine = 0
    tempLow = 0
    tempHigh = 0
    tempStringArray = []
    quarentineContainer = []
    lowLineContainer = []
    highLineContainer = []
    for line in inFileR :
        lowLine = lowLine + 1
        for i in range(0, line.__len__()) :
            if line[i:i+2] == "//" :
                for j in range(0, line.__len__()) :
                    if line[j:j+1] == ";" :
                        quarentineContainer.append(line)
                        lowLineContainer.append(str(lowLine))
                        highLineContainer.append(str(lowLine))
            if line[i:i+2] == "/*" :
                print("foo")
                tempHigh, tempStringArray = CommentBlockCheck(lowLine, inFileR)
                if tempHigh != 0 :     
                    quarentineContainer.append(tempStringArray)
                    lowLineContainer.append(str(lowLine))
                    highLineContainer.append(str(tempHigh))
    
    Quarentine(oFile, qFile, quarentineContainer, lowLineContainer, highLineContainer)

def CommentBlockCheck(lowLine, inFileR) :
    print("bar")
    tempLow = 0
    tempHigh = 0
    tempStringArray = []
    for line in inFileR :
        tempLow = tempLow + 1
        if tempLow >= lowLine :
            for i in range(0, line.__len__()) :
                if line[i:i+1] == ";" :
                    tempStringArray.append(line)
                    tempHigh = tempLow
                if line[i:i+2] == "*/" and tempHigh != 0 :
                    tempStringArray.append(line)
                    tempHigh = tempLow
                    return tempHigh, tempStringArray
                elif line[i:i+2] == "*/" and tempHigh == 0 :
                    return 0, []

    print("ERROR")
                    
    
def Quarentine(oFile, qFile, quarentineContainer, lowLineContainer, highLineContainer) :
    for i in range(0, quarentineContainer.__len__()) :
        qFile.write("The commented code began at line " + lowLineContainer[i] + " and ended at line " + highLineContainer[i] + "\n")
        qFile.write("The commented code is shown below:" + "\n")
        qFile.write(quarentineContainer[i] + "\n \n")
    
    BuildClean(inFileR, oFile, lowLineContainer, highLineContainer)
        

def BuildClean(inFileR, oFile, lowLineContainer, highLineContainer) :
    pass

CheckForComments(inFileR, qFile, oFile)

inFileR.close()
oFile.close()
qFile.close()