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
            var rawData = File.ReadAllLines(filename)
                .Select(line => line.ToCharArray()
                .Select(item => int.Parse(item.ToString()))
                .ToArray());
                

            return new Forest(rawData);
        }
    }
}
