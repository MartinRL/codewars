using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    class Pong
    {
        private readonly int maxScore;
        private const int paddleHeight = 7;
        private bool currentPlayer;
        private readonly IDictionary<bool, int> scores = new Dictionary<bool, int>
        {
            { false, 0 },
            { true, 0 }
        };
        
        public Pong(int maxScore)
        {
            this.maxScore = maxScore;
        }

        public string play(int ballPos, int playerPos)
        {
            var msg = string.Empty;

            if (maxScore <= 0)
                return "This game doesn't make sense...";
            
            if (Enumerable.Range(playerPos - paddleHeight / 2, paddleHeight).Contains(ballPos))
            {
                msg = scores[currentPlayer] == maxScore ? "Game Over!" : $"Player {PlayerNumber} has hit the ball!";
                ChangePlayer();
                
                return msg;
            }

            msg = $"Player {PlayerNumber} has missed the ball!";
            ChangePlayer();
            scores[currentPlayer]++;

            if (scores[currentPlayer] == maxScore)
            {
                msg = $"Player {PlayerNumber} has won the game!";
            }

            return msg;
        }

        private void ChangePlayer()
        {
            currentPlayer = !currentPlayer;
        }

        private int PlayerNumber => currentPlayer ? 2 : 1;
    }

    public class PongBasicsTests
    {
        [Fact]
        public void PlayGameShouldAdhereToTheRules()
        {
            var game = new Pong(2);

            game.play(50, 53).Should().Be("Player 1 has hit the ball!");
            game.play(100, 97).Should().Be("Player 2 has hit the ball!");
            game.play(0, 4).Should().Be("Player 1 has missed the ball!");
            game.play(25, 25).Should().Be("Player 2 has hit the ball!");
            game.play(75, 25).Should().Be("Player 2 has won the game!");
            game.play(50, 50).Should().Be("Game Over!");
        }
    }
}
