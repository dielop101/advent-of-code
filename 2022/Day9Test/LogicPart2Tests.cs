using Day9;
using FluentAssertions;

namespace Day9Test;

public class LogicPart2Tests
{
    [TestCase(@"data\example.txt", 1)]
    [TestCase(@"data\example2.txt", 36)]
    public void Part2(string file, int total)
    {
        var result = LogicPart2.Part2(file);
        result.Should().Be(total);
    }
}