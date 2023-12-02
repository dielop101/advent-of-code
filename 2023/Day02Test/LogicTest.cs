namespace _2023.Day02;

public class LogicTest
{
    [Test]
    public void Example()
    {
        var sumPossibleGames = Logic.SumPossibleGames(@"data\example.txt", (12,13,14));

        sumPossibleGames.Should().Be(8);
    }
}