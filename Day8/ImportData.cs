using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    internal class ImportData
    {
        internal static Forest GetData(string filename)
        {
            var outputList = new List<int[]>();
            var rawData = System.IO.File.ReadAllLines(filename);
            foreach (var line in rawData)
            {
                var chars = line.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
                outputList.Add(chars);
            }

            return new Forest(outputList);
        }
    }
}
