using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    internal class ImportData
    {
        internal static char[] GetData(string fileName)
        {
            char[] output = System.IO.File.ReadAllText(fileName).ToCharArray();

            return output;
        }
    }
}
