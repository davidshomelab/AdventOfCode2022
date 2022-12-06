namespace Day6
{
    internal class Program
    {

        static int FindMarker(char[] message, int markerLength)
        {
            for (int i = markerLength; i < message.Length; i++)
            {

                char[] sectionToCheck = message.Skip(i - markerLength).Take(markerLength).ToArray();

                char[] distinctValues = sectionToCheck.Distinct().ToArray();

                if (distinctValues.Count() == markerLength)
                {
                    return i;
                }

            }

            throw new InvalidOperationException("Message does not contain a marker of the specified length");
        }

        static void Main(string[] args)
        {
            char[] data = ImportData.GetData("input.txt");

            Console.WriteLine($"Part 1: {FindMarker(data,4)}");
            Console.WriteLine($"Part 2: {FindMarker(data,14)}");
        }
    }
}