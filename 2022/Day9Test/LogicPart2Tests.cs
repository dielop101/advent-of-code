using Day9;
using FluentAssertions;

namespace Day9Test;

public class LogicPart2Tests
{
    [Test]
    public void Part2()
    {
        var result = LogicPart2.Part2(@"data\example.txt");
        result.Should().Be(13);
    }
}