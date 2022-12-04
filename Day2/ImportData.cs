using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal static class ImportData
    {
        internal static List<Game> importGames(string FileName, InputFormat inputFormat = InputFormat.Plays)
        {
            string[] gamesRaw = File.ReadAllLines(FileName);

            List<Game> output = new List<Game>();

            foreach (string game in gamesRaw)
            {
                string[] choices = game.Split(' ');
                RockPaperScisors player1Choice = choices[0] switch
                {
                    "A" => RockPaperScisors.Rock,
                    "B" => RockPaperScisors.Paper,
                    "C" => RockPaperScisors.Scisors,
                    _ => throw new InvalidOperationException("Valid choices for player 1 are A,B and C")
                };
                if (inputFormat == InputFormat.Plays)
                {
                    RockPaperScisors player2Choice = choices[1] switch
                    {
                        "X" => RockPaperScisors.Rock,
                        "Y" => RockPaperScisors.Paper,
                        "Z" => RockPaperScisors.Scisors,
                        _ => throw new InvalidOperationException("Valid choices for player 2 are X,Y and Z")
                    };

                    output.Add(new Game(player1Choice, player2Choice));
                }
                else
                {
                    GameResult gameResult = choices[1] switch
                    {
                        "X" => GameResult.Loss,
                        "Y" => GameResult.Draw,
                        "Z" => GameResult.Win,
                        _ => throw new InvalidOperationException("Valid choices for game result are X,Y and Z")
                    };

                    output.Add(new Game(player1Choice, gameResult));
                }

            }

            return output;
        }
    }
}
