using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    internal class Instruction
    {
        public int SourceColumn { get; set; }
        public int TargetColumn { get; set; }
        public int ContainersToMove { get; set; }

        internal Instruction(int SourceColumn,int TargetColumn , int Count)
        {
            this.SourceColumn = SourceColumn;
            this.TargetColumn = TargetColumn;
            this.ContainersToMove = Count;
        }
    }
}
