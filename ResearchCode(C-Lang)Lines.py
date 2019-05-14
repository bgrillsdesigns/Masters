#Author: Blake Grills
#This program is being used to analyze c-lang code 
#in order to find, quarentine, and then rebuild a program
#of all commented out code

import sys
import glob
import os

def CheckForComments(inFileR, resultsFile) :
    lines = 0
    linesC = 0
    block = False

    for line in inFileR :
        lines = lines + 1
        for i in range(0,line.__len__()) :
            if line[i:i+2] == "//" :
                linesC = linesC + 1
            elif line[i:i+2] == "/*" :
                block = True
                linesC = linesC + 1
            elif block == True and line[i:i+2] != "/*" :
                linesC = linesC + 1
            if line[i:i+2] == "*/" :
                block = False

    return lines, linesC
path = sys.argv[-1]

resultsFileName = "%s %s" % (path, "resultsLines2.md")
resultsFile = open(resultsFileName, "w")
resultsFile.write("Lines : \n")

temp = 0
tempC = 0
countL = 0
countC = 0
for fileName in glob.glob(os.path.join(path, '*quarentine.md')) :
    inFileR = open(fileName, "r")
    temp, tempC = CheckForComments(inFileR, resultsFile)

    inFileR.close()
    countL = countL + temp
    countC = countC + tempC

resultsFile.write("%s %s" % ("number of lines:", countL))
resultsFile.write("%s %s" % ("number of Comments:", countC))
resultsFile.close()

