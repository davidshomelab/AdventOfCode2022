using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    /// <summary>
    /// Represents possible selections in a game of Rock, Paper, Scisors
    /// Enum values represent score assigned to each choice
    /// </summary>
    internal enum RockPaperScisors
    {
        Rock = 1,
        Paper = 2,
        Scisors = 3
    }

    /// <summary>
    /// Represents possible results from player 2's perspective
    /// Enum values represent score assigned to each result
    /// </summary>
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
