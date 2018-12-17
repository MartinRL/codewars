using FluentAssertions;
using Xunit;

namespace codewars
{
    class Pong
    {
        private int maxScore;
        
        public Pong(int maxScore)
        {
            this.maxScore = maxScore;
        }

        public string play(int ballPos, int playerPos)
        {
            return "";
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
