using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class Directory
    {
        /// <summary>
        /// The parent directory
        /// </summary>
        internal Directory Parent { get; private set; }

        /// <summary>
        /// Directory name
        /// </summary>
        internal string Name { get; init; }

        /// <summary>
        /// Collection of direct subdirectories
        /// </summary>
        internal HashSet<Directory> Children { get; } = new HashSet<Directory>();

        /// <summary>
        /// Collection of files directly inside directory
        /// </summary>
        internal HashSet<File> Files { get; } = new HashSet<File>();

        /// <summary>
        /// Get total size of all files directly within directory, don't include subdirectories
        /// </summary>
        internal int TotalFileSize
        {
            get
            {
                return Files.Select(x => x.Size).Sum();
            }
        }

        /// <summary>
        /// Get total size of all files in this directory and all subdirectories
        /// </summary>
        internal int TotalSubtreeSize
        {
            get
            {
                // We recursively generate a list of the total file sizes of all subdirectories by calling TotalSubtreeSize
                // on all child directories, this propogates down to the leaf directories and then sums back up using
                // the TotalFileSize values
                return TotalFileSize + Children.Sum(x => x.TotalSubtreeSize);
            }
        }

        /// <summary>
        /// Create a new file in the directory
        /// </summary>
        /// <param name="file">File to add</param>
        internal void AddFile(File file)
        {
            Files.Add(file);
        }

        /// <summary>
        /// Create a new subdirectory
        /// </summary>
        /// <param name="directory">Directory object to add</param>
        internal void AddDirectory(Directory directory)
        {
            directory.Parent = this;
            Children.Add(directory);
        }

        /// <summary>
        /// Create new directory object
        /// </summary>
        /// <param name="name">Name of directory</param>
        internal Directory(string name)
        {
            Name = name;

            // Typically when we create a directory by adding a child to an existing directory,
            // the AddDirectory method is responsible for setting the parent. An exception is made if
            // we are creating the root of a directory tree "/" in which case it becomes its own parent
            if (name == "/")
            {
                Parent = this;
            }
        }
    }
}
