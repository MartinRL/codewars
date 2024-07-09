namespace codewars;

class Pong(int maxScore)
{
    private readonly int maxScore = maxScore;
    private int currentPlayer;
    private readonly int[] scores = { 0, 0 };

    public string play(int ballPos, int playerPos)
    {
        if (scores.Any(_ => _ == maxScore))
            return "Game Over!";

        var scoreIndex = (currentPlayer + 1) % 2;

        var msg = Math.Abs(playerPos - ballPos) > 3
            ? ++scores[scoreIndex] == maxScore
                ? $"Player {scoreIndex + 1} has won the game!"
                : $"Player {currentPlayer + 1} has missed the ball!"
            : $"Player {currentPlayer + 1} has hit the ball!";

        currentPlayer = scoreIndex;

        return msg;
    }
}

public class PongBasicsTests
{
    [Fact]
    public void PlayGameToOne()
    {
        var game = new Pong(1);

        game.play(75, 25).Should().Be("Player 2 has won the game!");
        game.play(50, 50).Should().Be("Game Over!");
    }

    [Fact]
    public void PlayGameToTwo()
    {
        var game = new Pong(2);

        game.play(50, 53).Should().Be("Player 1 has hit the ball!");
        game.play(100, 97).Should().Be("Player 2 has hit the ball!");
        game.play(0, 4).Should().Be("Player 1 has missed the ball!");
        game.play(25, 25).Should().Be("Player 2 has hit the ball!");
        game.play(75, 25).Should().Be("Player 2 has won the game!");
        game.play(50, 50).Should().Be("Game Over!");
    }

    [Fact]
    public void PlayGameToThree()
    {
        var game = new Pong(3);

        game.play(0, 4).Should().Be("Player 1 has missed the ball!");
        game.play(100, 97).Should().Be("Player 2 has hit the ball!");
        game.play(0, 4).Should().Be("Player 1 has missed the ball!");
        game.play(25, 25).Should().Be("Player 2 has hit the ball!");
        game.play(0, 4).Should().Be("Player 2 has won the game!");
        game.play(50, 50).Should().Be("Game Over!");
    }
}
