using System.Text.RegularExpressions;

namespace Day1
{
    internal class Program
    {
        static int GetTotalCalories(List<int[]> Data, int ElvesToConsider)
        {
            List<Elf> Elves = new List<Elf>();

            foreach (int[] elfData in Data)
            {
                Elves.Add(new Elf(elfData));
            }

            List<Elf> OrderedElves = Elves.OrderByDescending(x => x.TotalCalories).ToList();

            List<Elf> ConsideredElves = OrderedElves.Take(ElvesToConsider).ToList();

            return ConsideredElves.Sum(x => x.TotalCalories);
        }
        static void Main(string[] args)
        {
            List<int[]> Data = ImportData.GetData("data.txt");

            Console.WriteLine($"Part 1: {GetTotalCalories(Data, 1)}");
            Console.WriteLine($"Part 2: {GetTotalCalories(Data, 3)}");
        }
    }
}