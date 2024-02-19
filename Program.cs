using System;
using System.Collections.Generic;
using System.IO;
namespace ReadModifyWriteCSVFile;
class Program
{
    static void Main(string[] args)
    {
        ReadModifyWriteCSVFile readCSV = new ReadModifyWriteCSVFile();
        readCSV.InputFilePath = @"c:\Users\parsh\Documents\Book1.csv";
        readCSV.OutputFilePath = @"c:\Users\parsh\Documents\newout.csv";
        readCSV.columtomodify = 3;

        List<string[]> modifiedData = readCSV.ModifyColumn(readCSV.InputFilePath, readCSV.columtomodify);
        readCSV.saveToCsv(readCSV.OutputFilePath, modifiedData);
        Console.WriteLine("The CSV file has been modified and saved");
    }
}