using Day01;

namespace _2024.Day01Test;

public class LogicTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CalculatePath()
    {
        var result = Logic.CalculatePath(@"data\example.txt", true);
        result.Should().Be(11);
    }

    [Test]
    public void CalculateSimilarity()
    {
        var result = Logic.CalculatePath(@"data\example.txt", false);
        result.Should().Be(31);
    }
}