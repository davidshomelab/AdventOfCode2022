using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class ImportData
    {
        internal static List<string[]> GetData(string fileName)
        {
            // All command tokens are single line and separated by spaces so we make a list of arrays
            // with one token per element to simplify parsing later
            string[] lines = System.IO.File.ReadAllLines(fileName);

            List<string[]> output = new List<string[]>();

            foreach (string line in lines)
            {
                output.Add(line.Split(" "));
            }

            return output;
        }
    }
}
