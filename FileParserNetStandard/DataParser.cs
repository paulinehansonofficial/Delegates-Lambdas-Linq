using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FileParserNetStandard {
    public class DataParser {


        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data)
        {
            for (int rowIndex = 0; rowIndex < data.Count; rowIndex++)
            {
                for (int colIndex = 0; colIndex < data[rowIndex].Count; colIndex++)
                {
                    data[rowIndex][colIndex] = data[rowIndex][colIndex].Replace(" ", "");
                }

            }
            return data;
        }



        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data)
        {
            for (int rowIndex = 0; rowIndex < data.Count; rowIndex++)
            {
                for (int colIndex = 0; colIndex < data[rowIndex].Count; colIndex++)
                {
                    data[rowIndex][colIndex] = data[rowIndex][colIndex].Replace("\"", "");
                }

            }
            return data;
        }

    }
}