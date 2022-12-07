using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    /// <summary>
    /// Represent a file object
    /// </summary>
    internal class File
    {
        /// <summary>
        /// Name of the file
        /// </summary>
        internal string Name { get; set; }
        /// <summary>
        /// Size of the file
        /// </summary>
        internal int Size { get; set; }

        /// <summary>
        /// Create new file object
        /// </summary>
        /// <param name="name">Name of the file</param>
        /// <param name="size">Size of the file</param>
        internal File(string name, int size)
        {
            Name = name;
            Size = size;
        }
    }
}
