using _2022.Day2;
using FluentAssertions;

namespace Day2Test;

public class LogicPart1Test
{
    [Test]
    public void A_Y()
    {
        var result = LogicPart1.Round("A Y");

        result.Should().Be(8);
    }

    [Test]
    public void B_X()
    {
        var result = LogicPart1.Round("B X");

        result.Should().Be(1);
    }

    [Test]
    public void C_Z()
    {
        var result = LogicPart1.Round("C Z");

        result.Should().Be(6);
    }

    [Test]
    public void Part1()
    {
        var result = LogicPart1.TotalScore(@"data\example.txt");

        result.Should().Be(15);
    }
}