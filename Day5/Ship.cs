using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    internal class Ship
    {
        Dictionary<int, Stack<char>> _cargo = new();

        internal void AddCargo(int id, char container)
        {
            if (!_cargo.ContainsKey(id))
            {
                _cargo[id] = new Stack<char>();
            }
            if (container != ' ')
            {
                _cargo[id].Push(container);
            }
        }

        internal void MoveCargo(Instruction instruction, bool CanMoveMultiple = false)
        {
            Stack<char> target;
            if (CanMoveMultiple)
            {
                target = new Stack<char>();
            }
            else
            {
                target = _cargo[instruction.TargetColumn];
            }

            for (int i = 0; i < instruction.ContainersToMove; i++)
            {
                char item = _cargo[instruction.SourceColumn].Pop();

                target.Push(item);
            }

            if (CanMoveMultiple)
            {
                while (target.Count > 0)
                {
                    char item = target.Pop();
                    _cargo[instruction.TargetColumn].Push(item);
                }
            }
        }

        internal string GetTopContainers()
        {
            List<Stack<char>> stack = _cargo.Values.ToList();

            StringBuilder output = new StringBuilder();

            foreach (Stack<char> item in stack)
            {
                output.Append(item.Peek());
            }

            return output.ToString();
        }
    }
}
