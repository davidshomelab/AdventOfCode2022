namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tuple<Ship, List<Instruction>> Data = ImportData.GetData("input.txt");

            Ship ship = Data.Item1;
            List<Instruction> Instructions = Data.Item2;

            foreach (Instruction instruction in Instructions)
            {
                ship.MoveCargo(instruction);
            }

            Console.WriteLine($"Part 1: {ship.GetTopContainers()}");

            // reset the ship to original state
            Data = ImportData.GetData("input.txt");
            ship = Data.Item1;

            foreach (Instruction instruction in Instructions)
            {
                ship.MoveCargo(instruction, true);
            }

            Console.WriteLine($"Part 2: {ship.GetTopContainers()}");
        }
    }
}