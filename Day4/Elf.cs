using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class Elf
    {
        internal int RangeStart { get; set; }
        internal int RangeEnd { get; set; }

        internal int[] Range
        {
            get
            {
                return Enumerable.Range(RangeStart, RangeEnd - RangeStart + 1).ToArray();
            }
        }

        internal Elf(int rangeStart, int rangeEnd)
        {
            RangeStart = rangeStart;
            RangeEnd = rangeEnd;
        }
    }
}
