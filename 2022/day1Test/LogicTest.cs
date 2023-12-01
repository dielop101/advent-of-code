using _2022.Day1;

namespace _2022.Day1Test;

public class LogicTest
{
    [Test]
    public void Part1()
    {
        var elfWithMostCalories = Logic.GetElfWithMostCalories(@"data\example.txt");

        elfWithMostCalories.Should().Be(24000);
    }

    [Test]
    public void Part2()
    {
        var elfWithMostCalories = Logic.GetTotalSumOfCaloriesForThreTopElfs(@"data\example.txt");

        elfWithMostCalories.Should().Be(45000);
    }
}