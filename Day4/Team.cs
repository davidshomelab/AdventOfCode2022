using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class Team
    {
        internal Elf Elf1 { get; set; }
        internal Elf Elf2 { get; set; }

        internal bool ElvesFullyOverlap()
        {
            if (Elf1.RangeStart >= Elf2.RangeStart && Elf1.RangeEnd <= Elf2.RangeEnd) { return true; }
            if (Elf2.RangeStart >= Elf1.RangeStart && Elf2.RangeEnd <= Elf1.RangeEnd) { return true; }
            return false;
        }

        internal bool ElvesPartiallyOverlap()
        {
            if (Elf1.Range.Any( x => x == Elf2.RangeStart || x == Elf2.RangeEnd)) { return true; }
            if (Elf2.Range.Any( x => x == Elf1.RangeStart || x == Elf1.RangeEnd)) { return true; }
            return false;
        }

        internal Team(Elf elf1, Elf elf2)
        {
            this.Elf1 = elf1;
            this.Elf2 = elf2;
        }
    }
}
