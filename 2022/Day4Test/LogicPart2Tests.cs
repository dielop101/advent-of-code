using _2022.Day4;
using FluentAssertions;

namespace Day4Test;

public class LogicPart2Tests
{
    [TestCase("2-4", "6-8", false)]
    [TestCase("5-7", "7-9", true)]
    public void AnyContains(string section1, string section2, bool spectedResult)
    {
        var result = LogicPart2.AnyContains(section1, section2);
        result.Should().Be(spectedResult);
    }

    [Test]
    public void Part2()
    {
        var result = LogicPart2.Part2(@"data\example.txt");

        result.Should().Be(4);
    }
}