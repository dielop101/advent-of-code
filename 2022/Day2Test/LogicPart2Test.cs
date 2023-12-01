using _2022.Day2;
using FluentAssertions;

namespace Day2Test;

public class LogicPart2Test
{
    [Test]
    public void A_Y()
    {
        var result = LogicPart2.Round("A Y");

        result.Should().Be(4);
    }

    [Test]
    public void B_X()
    {
        var result = LogicPart2.Round("B X");

        result.Should().Be(1);
    }

    [Test]
    public void C_Z()
    {
        var result = LogicPart2.Round("C Z");

        result.Should().Be(7);
    }

    [Test]
    public void Part1()
    {
        var result = LogicPart2.TotalScore(@"data\example.txt");

        result.Should().Be(12);
    }
}