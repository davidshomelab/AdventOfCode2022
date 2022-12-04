using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal class ImportData
    {
        internal static string[] GetData(string file)
        {
            return File.ReadAllLines(file);
        }
    }
}
