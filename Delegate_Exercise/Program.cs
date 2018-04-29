using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FileParserNetStandard;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise {
 
    
    internal class Delegate_Exercise {

        private static string inputPath = @"C:\Users\Michelle\Projects\Dip-Seminar-Delegates-Lambda-Linq_Exercises\data.csv";
        private static string outputPath = @"C:\Users\Michelle\Projects\Dip-Seminar-Delegates-Lambda-Linq_Exercises\processed_data.csv";

        public static void Main(string[] args) {

            Func<List<List<string>>, List<List<string>>> cleanData = new Func<List<List<string>>, List<List<string>>>(StripWhiteSpaceAndQuotes);
            cleanData += StripHashes;

            CsvHandler csv = new CsvHandler();
            
            csv.ProcessCsv(inputPath, outputPath, cleanData);

        }

        public static List<List<string>> StripWhiteSpaceAndQuotes(List<List<string>> data)
        {
            DataParser dp = new DataParser();
            data = dp.StripQuotes(data);
            data = dp.StripWhiteSpace(data);
            return data;
        }

        public static List<List<string>> StripHashes(List<List<string>> data)
        {
            for (int rowIndex = 0; rowIndex < data.Count; rowIndex++)
            {
                for(int colIndex = 0; colIndex < data[rowIndex].Count; colIndex++)
                {
                    data[rowIndex][colIndex] = data[rowIndex][colIndex].Replace("#", "");
                }

            }
            return data;
        }

    }
}