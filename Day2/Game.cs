using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    /// <summary>
    /// Models a game of Rock, Paper, Scisors
    /// </summary>
    internal class Game
    {
        RockPaperScisors _player1Choice;
        RockPaperScisors _player2Choice;

        GameResult _result;

        /// <summary>
        /// Returns sum of player 2 choice and result
        /// </summary>
        public int GameScore
        {
            get
            {
                return (int)_player2Choice + (int)_result;
            }
        }

        /// <summary>
        /// Construct game of Rock, Paper, Scisors based on player 1 and 2 choices
        /// </summary>
        /// <param name="player1Choice">Option chosen by player 1</param>
        /// <param name="player2Choice">Option chosen by player 2</param>
        /// <exception cref="InvalidOperationException"></exception>
        internal Game(RockPaperScisors player1Choice, RockPaperScisors player2Choice)
        {
            _player1Choice = player1Choice;
            _player2Choice = player2Choice;

            /* Here we calculate the result of the game from player 2's perspective
             * This is calculated by taking the difference between the player's choices modulo 3
             * If the choices are the same, the difference will be 0 and the game will be a draw
             * If the result is 1 or -2 player 1 wins
             * If the result is 2 or -1 player 2 wins
             * As 1 and -2 and 2 and -1 are different representations of the same value when considered
             * modulo 3, we add 3 and take the modulus at the end to force a positive representation
             */
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

            /* As the result enum values represent the scores for each result, we divide to get:
             *  Loss = 0
             *  Draw = 1
             *  Win = 2
             * We then subtract 1 so a draw is represented as no change and a win or a loss are represented
             * by adding or subtraciting 1 respectively
             */
            int resultOffset = ((int)_result / 3) - 1;

            /* It's easier to model this if our player choice enum counts from 0 to 2 instead of 1 to 3 so we subtract 1
             * We then apply our results offset, if the offset is 0 then we know the game was a draw so player 2 must have played the same as player 1
             * If the offset is +1 we know the result is a win for player 2 so we know player 2 must have played the next option above player 1
             * If the offset is -1 we know the result is a win for player 1 so player 2 must have played the option below player 1
             * As before, we use modulo 3 to remove overflows and then add 3 and take the modulo again to remove negatives
             * Finally we must re-add the 1 we took off in the first step
             */
            _player2Choice = (RockPaperScisors)(((((int)_player1Choice - 1 + resultOffset) % 3) + 3) % 3 + 1);
        }
    }
}
