using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FileParserNetStandard{
    public class FileHandler
    {
       
        public FileHandler() { }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> ReadFile(string filePath) {

            string[] linesArray = File.ReadAllLines(filePath);
            List<string> lines = new List<string>(linesArray);

            return lines;
        }     
        

        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        /// 

       // get each row from the list
       // write each row to an array with the delimeter between each string
       // write the array to the file

        public void WriteFile(string filePath, char delimeter, List<List<string>> rows) {

            string delimitedRow = "";
            List<string> lineList = new List<string>();

            foreach (List<string> row in rows) {

                for (int i = 0; i < row.Count-1; i++) {

                    delimitedRow += row[i] + delimeter;

                }

                delimitedRow += row[row.Count-1];
                lineList.Add(delimitedRow);
                delimitedRow = "";
            }

            File.WriteAllLines(filePath, lineList.ToArray());
        }


        
        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimeter"></param>
        /// <returns></returns>
        /// 
        public List<List<string>> ParseData(List<string> data, char delimeter) {

            List<List<string>> parsedData = new List<List<string>>();

            foreach (string row in data) {
                List<string> parsedRow = new List<string>(row.Split(delimeter));

                parsedData.Add(parsedRow);
            }

            return parsedData;
        }
        
        /// <summary>
        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> ParseCsv(List<string> data) {

            List<List<string>> parsedData = new List<List<string>>();

            foreach(string row in data) {
                List<string> parsedRow = new List<string>(row.Split(','));

                parsedData.Add(parsedRow);
            }

            return parsedData;
        }
    }
}