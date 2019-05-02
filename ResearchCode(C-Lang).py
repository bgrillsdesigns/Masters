#Author: Blake Grills
#This program is being used to analyze c-lang code 
#in order to find quarentine and then rebuild a program
#of all commented out codes

import sys
import glob
import os

def CheckForComments(fileName, fileCP, fileQuar, inFileR, qFile, oFile, resultsFile) :
    lowLine = 0
    tempHigh = 0
    tempStringArray = []
    quarentineContainer = []
    lowLineContainer = []
    highLineContainer = []
    for line in inFileR :
        lowLine = lowLine + 1
        for i in range(0, line.__len__()) :
            if line[i:i+1] == ";" :
                break
            if line[i:i+2] == "//" :
                for j in range(0, line.__len__()) :
                    if line[j:j+1] == ";" or line[i:i+1] == ")" :
                        quarentineContainer.append(line)
                        lowLineContainer.append(str(lowLine))
                        highLineContainer.append(str(lowLine))
            if line[i:i+2] == "/*" :
                tempHigh, tempStringArray = CommentBlockCheck(lowLine, inFileR, line)
                if tempHigh != 0 :     
                    quarentineContainer.append(tempStringArray)
                    lowLineContainer.append(str(lowLine + 1))
                    highLineContainer.append(str(tempHigh))
                    lowLine = tempHigh - 1
    
    Quarentine(fileName, fileCP, fileQuar, inFileR, oFile, qFile, resultsFile, quarentineContainer, lowLineContainer, highLineContainer)

def CommentBlockCheck(lowLine, inFileR, line) :
    tempLow = 1
    tempHigh = 0
    containsComments = False
    tempStringArray = line

    for line in inFileR :
        tempLow = tempLow + 1
        tempStringArray = ("%s %s") % (tempStringArray, line)

        for i in range(0, line.__len__()) :
            if line[i:i+1] == ";" or line[i:i+1] == ")" or line[i:i+1] == "{" :
                containsComments = True
            if containsComments == True and line[i:i+2] == "*/" :
                tempHigh = tempLow
                semicolon = tempStringArray.find(";")
                if(semicolon == -1) :
                    return 0, ""
                return tempHigh + lowLine, tempStringArray             
            elif containsComments == False and line[i:i+2] == "*/" :
                return 0, ""
    print(inFileR, "error")

  
def Quarentine(fileName, fileCP, fileQuar, inFileR, oFile, qFile, resultsFile, quarentineContainer, lowLineContainer, highLineContainer) :
    if(quarentineContainer.__len__() > 0) :
        resultsFile.write("%s %s %s %s" % (inFileR, "contains", quarentineContainer.__len__(), "sections of commented out code. \n"))

    for i in range(0, quarentineContainer.__len__()) :
        qFile.write("The commented code began at line " + lowLineContainer[i] + " and ended at line " + highLineContainer[i] + "\n")
        qFile.write("The commented code is shown below:" + "\n")
        qFile.write(quarentineContainer[i] + "\n" + "\n")

    if(quarentineContainer.__len__() == 0) :
        qFile.close()
        os.remove(fileQuar)  
    else :
        qFile.close()

    inFileR.close()
    inFileR = open(fileName, "r")
    BuildClean(fileCP, fileQuar, inFileR, oFile, lowLineContainer, highLineContainer)
        

def BuildClean(fileCP, fileQuar, inFileR, oFile, lowLineContainer, highLineContainer) :
    tempLine = 1
    i = 0
    blockTracer = False
    
    for line in inFileR :
        if (lowLineContainer.__len__() > 0) :
            if (int(lowLineContainer[i]) == tempLine and lowLineContainer[i] == highLineContainer[i]) :
                oFile.write("//commented out code was ommited here \n")
                i = i + 1
                if (i == highLineContainer.__len__()) :
                    i = highLineContainer.__len__() - 1
            elif (int(lowLineContainer[i]) == tempLine and lowLineContainer[i] < highLineContainer[i]) :
                oFile.write("//commented out code was ommited here \n")
                blockTracer = True
            elif (blockTracer == True and tempLine <= int(highLineContainer[i])) :
                oFile.write("//commented out code was ommited here \n")
                if(tempLine == int(highLineContainer[i])) :
                    blockTracer = False
                    i = i + 1
                    if (i == highLineContainer.__len__()) :
                        i = highLineContainer.__len__() - 1
            else :
                oFile.write("%s" %(line))
        else :
            oFile.write("%s" %(line))
        tempLine = tempLine + 1
    
    if(lowLineContainer.__len__() == 0) :
        oFile.close()
        os.remove(fileCP)  
    else : 
        oFile.close()


resultsFile = open("resultsFile.md", "w")
resultsFile.write("The following files contain commented out code(included is the frequency) : \n")
cp = "CleanedProgram.cs"
quar = "quarentine.md"

path = sys.argv[-1]
for fileName in glob.glob(os.path.join(path, '*.cs')) :
    inFileR = open(fileName, "r")
    fileCP = "%s %s" % (fileName[0:-3], cp)
    fileQuar = "%s %s" % (fileName[0:-3], quar)
    oFile = open(fileCP, "w")
    qFile = open(fileQuar, "w")

    CheckForComments(fileName, fileCP, fileQuar, inFileR, qFile, oFile, resultsFile)

    inFileR.close()

resultsFile.close()

