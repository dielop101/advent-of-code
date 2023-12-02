namespace _2023.Day02;

public class LogicTest
{
    [Test]
    public void Example()
    {
        var sumPossibleGames = Logic.SumPossibleGames(@"data\example.txt", (12, 13, 14));

        sumPossibleGames.Should().Be(8);
    }
    [Test]
    public void Example2()
    {
        var multiplyMaxCubes = Logic.MultiplyMaxCubes(@"data\example.txt");

        multiplyMaxCubes.Should().Be(2286);
    }
}