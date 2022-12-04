namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Game> games = ImportData.importGames("input.txt", InputFormat.Plays);

            int result = games.Sum(x => x.GameScore);
            Console.WriteLine($"Part 1: {result}");
            
            games = ImportData.importGames("input.txt", InputFormat.Result);

            result = games.Sum(x => x.GameScore);
            Console.WriteLine($"Part 2: {result}");
        }
    }
}