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
                    if line[j:j+1] == ";" or line[i:i+1] == ")" :
                        quarentineContainer.append(line)
                        lowLineContainer.append(str(lowLine))
                        highLineContainer.append(str(lowLine))
            if line[i:i+2] == "/*" :
                print("foo")
                tempHigh, tempStringArray = CommentBlockCheck(lowLine, inFileR, line)
                if tempHigh != 0 :     
                    quarentineContainer.append(tempStringArray)
                    lowLineContainer.append(str(lowLine + 1))
                    highLineContainer.append(str(tempHigh))
                    lowLine = tempHigh - 1
    
    Quarentine(inFileR, oFile, qFile, quarentineContainer, lowLineContainer, highLineContainer)

def CommentBlockCheck(lowLine, inFileR, line) :
    print("bar")
    tempLow = 1
    tempHigh = 0
    tempStringArray = line
    for line in inFileR :
        print("foo2")
        tempLow = tempLow + 1
        
        print("test")
        for i in range(0, line.__len__()) :
            if line[i:i+1] == ";" or line[i:i+1] == ")" :
                tempStringArray = "%s %s" % (tempStringArray, line)
                tempHigh = tempLow
            if line[i:i+2] == "*/" and tempHigh != 0 :
                print("bar2")
                tempStringArray = "%s %s" % (tempStringArray, line)
                tempHigh = tempLow
                print(tempStringArray)
                return tempHigh + lowLine, tempStringArray
            elif line[i:i+2] == "*/" and tempHigh == 0 :
                print("bar3")
                return 0, ""

    print("ERROR")
                    
    
def Quarentine(inFileR, oFile, qFile, quarentineContainer, lowLineContainer, highLineContainer) :
    for i in range(0, quarentineContainer.__len__()) :
        qFile.write("The commented code began at line " + lowLineContainer[i] + " and ended at line " + highLineContainer[i] + "\n")
        qFile.write("The commented code is shown below:" + "\n")
        qFile.write(quarentineContainer[i] + "\n" + "\n")
    
    inFileR.close()
    #infileR = open(sys.argv[-1], "r")
    inFileR = open("TestingProgram.cpp", "r")

    BuildClean(inFileR, oFile, lowLineContainer, highLineContainer)
        

def BuildClean(inFileR, oFile, lowLineContainer, highLineContainer) :
    tempLine = 1
    i = 0
    blockTracer = False
    for line in inFileR :

        if (int(lowLineContainer[i]) == tempLine and lowLineContainer[i] == highLineContainer[i]) :
            print("clean1")
            oFile.write("//commented out code was ommited here \n")
            i = i + 1
            if (i == highLineContainer.__len__()) :
                    i = highLineContainer.__len__() - 1
        elif (int(lowLineContainer[i]) == tempLine and lowLineContainer[i] < highLineContainer[i]) :
            print("clean2")
            oFile.write("//commented out code was ommited here \n")
            blockTracer = True
        elif (blockTracer == True and tempLine <= int(highLineContainer[i])) :
            print("clean3")
            oFile.write("//commented out code was ommited here \n")
            if(tempLine == int(highLineContainer[i])) :
                blockTracer = False
                i = i + 1
                if (i == highLineContainer.__len__()) :
                    i = highLineContainer.__len__() - 1
        else :
            oFile.write("%s" %(line))
        tempLine = tempLine + 1

CheckForComments(inFileR, qFile, oFile)

inFileR.close()
oFile.close()
qFile.close()