namespace Day8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = ImportData.GetData("input.txt");

            int VisibleTrees = 0;

            int BestScenicScore = 0;

            for (int i = 0; i < data.Width; i++)
            {
                for (int j = 0; j < data.Height; j++)
                {
                    if (data.IsVisibleFromEdge(j, i))
                    {
                        VisibleTrees++;
                    }

                    int scenicScore = data.ScenicScore(j, i);

                    if (scenicScore > BestScenicScore) { BestScenicScore = scenicScore; }
                }
            }

            Console.WriteLine($"Part 1: {VisibleTrees}");
            Console.WriteLine($"Part 2: {BestScenicScore}");

        }
    }
}