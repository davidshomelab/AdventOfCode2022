namespace Day7
{
    internal class Program
    {
        /// <summary>
        /// Traverse directory tree and return list of elements which satisfy condition
        /// </summary>
        /// <param name="condition">Filter expression by which to return data</param>
        /// <param name="root">Root directory in tree to search</param>
        /// <returns>List of diretories which satisfy condition</returns>
        static List<Directory> GetDirectoriesWhere(Func<Directory, bool> condition, Directory root)
        {
            List<Directory> output = new List<Directory>();

            if (condition(root))
            {
                output.Add(root);
            }

            foreach (Directory child in root.Children)
            {
                output = output.Concat(GetDirectoriesWhere(condition, child)).ToList();
            };

            return output;

        }
        static void Main(string[] args)
        {
            Cursor FolderStructure = new Cursor();

            List<string[]> data = ImportData.GetData("input.txt");

            // populate directory tree according to commands in input
            foreach (string[] line in data)
            {
                switch (line[0])
                {
                    case "$": // the only commands we get are cd and ls. We don't care about ls as we can detect it via other means
                        if (line[1] == "cd")
                        {
                            FolderStructure.GoTo(line[2]);
                        }
                        break;
                    case "dir": // dir lines indicate that a directory exists so we create one
                        FolderStructure.CurrentNode.AddDirectory(new Directory(line[1]));
                        break;
                    default: // all lines that don't start with $ or dir are files
                        FolderStructure.CurrentNode.AddFile(new File(line[1], int.Parse(line[0])));
                        break;

                }
            }

            // after importing our cursor will be somewhere at the bottom of the tree, go back to the root before we start reviewing the data
            FolderStructure.GoTo("/");

            List<Directory> DirectoriesSmallerThan10000 = GetDirectoriesWhere(x => x.TotalSubtreeSize < 100000, FolderStructure.CurrentNode);

            Console.WriteLine($"Part 1: {DirectoriesSmallerThan10000.Sum(x => x.TotalSubtreeSize)}");

            int TotalSpace = 70000000;

            int RequiredSpace = 30000000;

            int AvailableSpace = TotalSpace - FolderStructure.CurrentNode.TotalSubtreeSize;

            int MissingSpace = RequiredSpace - AvailableSpace;

            List<Directory> DeletionCandidates = GetDirectoriesWhere(x => x.TotalSubtreeSize >= MissingSpace, FolderStructure.CurrentNode);

            Directory? deletableDirectory = DeletionCandidates.MinBy(x => x.TotalSubtreeSize);
            Console.WriteLine($"Part 2: {deletableDirectory?.TotalSubtreeSize}");

        }
    }
}