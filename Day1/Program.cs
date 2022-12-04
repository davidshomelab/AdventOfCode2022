using System.Text.RegularExpressions;

namespace Day1
{
    internal class Program
    {
        /// <summary>
        /// Sorts a list of elves by descending total calories and returns the first N elves
        /// </summary>
        /// <param name="Elves">List of input elves</param>
        /// <param name="Count">Number of elves to return</param>
        /// <returns></returns>
        static int GetTotalCalories(List<Elf> Elves, int Count)
        {

            List<Elf> OrderedElves = Elves.OrderByDescending(x => x.TotalCalories).ToList();

            List<Elf> ConsideredElves = OrderedElves.Take(Count).ToList();

            return ConsideredElves.Sum(x => x.TotalCalories);
        }
        static void Main(string[] args)
        {
            List<Elf> Data = ImportData.GetData("data.txt");

            Console.WriteLine($"Part 1: {GetTotalCalories(Data, 1)}");
            Console.WriteLine($"Part 2: {GetTotalCalories(Data, 3)}");
        }
    }
}