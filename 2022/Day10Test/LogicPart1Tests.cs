using _2022.Day10;
using FluentAssertions;

namespace Day10Test;

public class LogicPart1Tests
{
    [Test]
    public void Part1()
    {
        var result = LogicPart1.Part1(@"data\example.txt");
        result.Should().Be(13140);
    }

    [TestCase("noop", 1, 0)]
    [TestCase("addx 3", 2, 3)]
    [TestCase("addx -5", 2, -5)]
    public void OperateInstruction(string instruction, int numCycles, int valueX)
    {
        var (resultNumCycles, resultValueX) = LogicPart1.OperateInstruction(instruction);
        resultNumCycles.Should().Be(numCycles);
        resultValueX.Should().Be(valueX);
    }
}