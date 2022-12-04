using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Day1
{
    internal static class ImportData
    {
        internal static List<Elf> GetData(string FileName)
        {
            List<int[]> ElfCalorieData = new List<int[]>();

            string rawData = File.ReadAllText(FileName);

            string[] sections = rawData.Split("\n\n");

            foreach (string section in sections)
            {
                if (!string.IsNullOrEmpty(section))
                {
                    int[] sectionData = section.Split("\n")
                        .Where(x=> !string.IsNullOrEmpty(x))
                        .Select(x => int.Parse(x)).ToArray();

                    ElfCalorieData.Add(sectionData);
                }
            }

            List<Elf> output = new List<Elf>();

            foreach (int[] elfData in ElfCalorieData)
            {
                output.Add(new Elf(elfData));
            }

            return output;

        }
    }
}
