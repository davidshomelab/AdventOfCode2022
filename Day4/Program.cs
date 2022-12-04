namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Team[] teams = ImportData.GetData("input.txt");
            int overlappingTeams = 0;
            int partiallyOverlappingTeams = 0;

            foreach (Team team in teams)
            {
                if (team.ElvesOverlap())
                {
                    overlappingTeams++;
                }

                if (team.ElvesPartiallyOverlap())
                {
                    partiallyOverlappingTeams++;
                }
            }

            Console.WriteLine($"Part 1: {overlappingTeams}");
            Console.WriteLine($"Part 2: {partiallyOverlappingTeams}");

        }

    }
}