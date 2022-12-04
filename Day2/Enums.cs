using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal enum RockPaperScisors
    {
        Rock = 1,
        Paper = 2,
        Scisors = 3
    }

    internal enum GameResult
    {
        Loss = 0,
        Draw = 3,
        Win = 6
    }

    internal enum InputFormat
    {
        Plays,
        Result
    }
}
