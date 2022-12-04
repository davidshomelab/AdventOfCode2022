using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class Game
    {
        RockPaperScisors _player1Choice;
        RockPaperScisors _player2Choice;

        GameResult _result;

        public int GameScore
        {
            get
            {
                return (int)_player2Choice + (int)_result;
            }
        }

        internal Game(RockPaperScisors player1Choice, RockPaperScisors player2Choice)
        {
            _player1Choice = player1Choice;
            _player2Choice = player2Choice;

            _result = (((((int)_player1Choice - (int)_player2Choice) % 3) + 3) % 3) switch
            {
                0 => GameResult.Draw,
                1 => GameResult.Loss,
                2 => GameResult.Win,
                _ => throw new InvalidOperationException("Game had no result, this should be impossible")
            };
        }

        internal Game(RockPaperScisors player1Choice, GameResult result)
        {
            _player1Choice = player1Choice;
            _result = result;

            int resultOffset = ((int)_result / 3) - 1;

            _player2Choice = (RockPaperScisors)(((((int)_player1Choice - 1 + resultOffset) % 3) + 3 ) % 3 + 1);
        }
    }
}
