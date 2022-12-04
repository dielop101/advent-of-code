using Day4;
using FluentAssertions;

namespace Day4Test;

public class LogicPart1Tests
{
    [Test]
    public void TakeAllNumbersBetweenRange()
    {
        var result = LogicPart1.TakeAllNumbersBetweenRange("2-5");
        result.Should().HaveCount(4);

        result = LogicPart1.TakeAllNumbersBetweenRange("6-6");
        result.Should().HaveCount(1);
    }

    [TestCase("2-4", "6-8", false)]
    [TestCase("6-6", "4-6", true)]
    [TestCase("3-7", "2-8", true)]
    [TestCase("8-8", "7-7", false)]
    public void FullyContains(string section1, string section2, bool spectedResult)
    {
        var result = LogicPart1.FullyContains(section1, section2);
        result.Should().Be(spectedResult);
    }

    [Test]
    public void Part1()
    {
        var result = LogicPart1.Part1(@"data\example.txt");

        result.Should().Be(2);
    }
}