using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day5
{
    internal class ImportData
    {
        internal static Tuple<Ship,List<Instruction>> GetData(string FileName)
        {
            string RawFile = File.ReadAllText(FileName);

            string[] sections = RawFile.Split("\n\n");

            // create stacks

            Ship ship = new Ship();

            List<string> splitStackSection = sections[0].Split("\n").Reverse().ToList();

            string indices = splitStackSection[0];

            splitStackSection.RemoveAt(0);

            for (int i = 1; i < indices.Length; i++)
            {
                if (int.TryParse(indices[i].ToString(), out int stackNumber))
                {
                    foreach (string column in splitStackSection)
                    {
                        ship.AddCargo(stackNumber, column[i]);
                    }
                }
            }

            // create list of move instructions

            List<Instruction> instructions = new List<Instruction>();

            string InstructionRegexPattern = "move (\\d+) from (\\d) to (\\d)";

            Regex PatternMatch = new Regex(InstructionRegexPattern, RegexOptions.Compiled);

            string[] instructionsArray = sections[1].Split("\n");

            foreach (string instructionText in instructionsArray.Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                Match match = PatternMatch.Match(instructionText);

                if (match.Groups != null)
                {
                    instructions.Add(new Instruction(int.Parse(match.Groups[2].Value)
                        , int.Parse(match.Groups[3].Value)
                        , int.Parse(match.Groups[1].Value)
                        ));
                }
            }

            return new Tuple<Ship, List<Instruction>>(ship, instructions);
        }
    }
}
