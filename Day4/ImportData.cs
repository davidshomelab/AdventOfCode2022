using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal static class ImportData
    {
        internal static Team[] GetData(string input)
        {
            string[] teamsData = File.ReadAllLines(input);

            List<Team> output = new List<Team>();

            foreach (string team in teamsData)
            {
                string[] elves = team.Split(',');

                List<Elf> elvesList = new List<Elf>();

                foreach (string elf in elves)
                {
                    int[] rangeEdges = elf.Split("-").Select(x => int.Parse(x)).ToArray();

                    elvesList.Add(new Elf(rangeEdges[0], rangeEdges[1]));
                }

                output.Add(new Team(elvesList[0], elvesList[1]));
            }
            return output.ToArray();
        }
    }
}
