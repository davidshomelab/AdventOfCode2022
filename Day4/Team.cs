using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class Team
    {
        internal Elf elf1 { get; set; }
        internal Elf elf2 { get; set; }

        internal bool ElvesOverlap()
        {
            if (elf1.RangeStart >= elf2.RangeStart && elf1.RangeEnd <= elf2.RangeEnd) { return true; }
            if (elf2.RangeStart >= elf1.RangeStart && elf2.RangeEnd <= elf1.RangeEnd) { return true; }
            return false;
        }

        internal bool ElvesPartiallyOverlap()
        {
            if (elf1.Range.Any( x => x == elf2.RangeStart || x == elf2.RangeEnd)) { return true; }
            if (elf2.Range.Any( x => x == elf1.RangeStart || x == elf1.RangeEnd)) { return true; }
            return false;
        }

        internal Team(Elf elf1, Elf elf2)
        {
            this.elf1 = elf1;
            this.elf2 = elf2;
        }
    }
}
