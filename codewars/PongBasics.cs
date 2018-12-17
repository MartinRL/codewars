using System;
using FluentAssertions;
using Xunit;

namespace codewars
{
    class Pong
    {
        private readonly int maxScore;
        private readonly int paddleHeight = 7;
        private int currentPlayer = 1;
        private int playerOneScore = 0;
        private int playerTwoScore = 0;
        
        public Pong(int maxScore)
        {
            this.maxScore = maxScore;
        }

        public string play(int ballPos, int playerPos)
        {
            if (ballPos + paddleHeight % 2 >= playerPos || ballPos - paddleHeight % 2 <= playerPos)
            {
                return $"Player {currentPlayer} has hit the ball!";
            }

            return string.Empty;
        }
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
