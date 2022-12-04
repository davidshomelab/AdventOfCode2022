namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data = ImportData.GetData("input.txt");

            List<Backpack> backpacks = new List<Backpack>();

            foreach (string line in data)
            {
                backpacks.Add(new Backpack(line));
            }

            List<int> outputs = new List<int>();

            foreach (Backpack backpack in backpacks)
            {
                Item[] AllItems = backpack.Compartment1.Concat(backpack.Compartment2).ToArray();

                Item[] DuplicateItems = AllItems.GetDuplicates().ToArray();

                int DuplicatesTotal = DuplicateItems.Select(x => x.Priority).Sum();

                outputs.Add(DuplicatesTotal);

            }

            Console.WriteLine($"Part 1: {outputs.Sum()}");


            List<IEnumerable<Backpack>> backpackGroups = backpacks.SplitInto(3).ToList();

            List<Item> Badges = new List<Item>();

            foreach (IEnumerable<Backpack> group in backpackGroups)
            {
                List<Item> AllItemsInGroup = new List<Item>();
                foreach (Backpack backpack in group)
                {
                    AllItemsInGroup = AllItemsInGroup.Concat(backpack.AllUniqueItems.ToList()).ToList();
                }

                Item BadgeItem = AllItemsInGroup.GetDuplicates(3).Single();

                Badges.Add(BadgeItem);
            }

            Console.WriteLine($"Part 2: {Badges.Select(x => x.Priority).Sum()}");
        }
    }
}