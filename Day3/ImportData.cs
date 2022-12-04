using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal class ImportData
    {
        internal static List<Backpack> GetData(string file)
        {
            string[] data = File.ReadAllLines(file);

            List<Backpack> output = new List<Backpack>();

            foreach (string line in data)
            {
                output.Add(new Backpack(line));
            }

            return output;
        }
    }
}
