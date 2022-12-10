using Day10;
using FluentAssertions;

namespace Day10Test;

public class LogicTests
{
    [TestCase(@"data\example1.txt", -5)]
    [TestCase(@"data\example2.txt", 13140)]
    public void Part1(string filepath, int total)
    {
        var result = Logic.Part1(filepath);
        result.Should().Be(total);
    }

    [TestCase("noop", 1, 0)]
    [TestCase("addx 3", 2, 3)]
    [TestCase("addx -5", 2, -5)]
    public void OperateInstruction(string instruction, int numCycles, int valueX)
    {
        var (resultNumCycles, resultValueX) = Logic.OperateInstruction(instruction);
        resultNumCycles.Should().Be(numCycles);
        resultValueX.Should().Be(valueX);
    }
}