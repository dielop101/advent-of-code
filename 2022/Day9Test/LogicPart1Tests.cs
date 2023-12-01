using _2022.Day9;
using FluentAssertions;

namespace Day9Test;

public class LogicPart1Tests
{
    [Test]
    public void Part1()
    {
        var result = LogicPart1.Part1(@"data\example.txt");
        result.Should().Be(13);
    }

    [Test]
    public void RemoveRepeatedCoordinates()
    {
        var list = new List<(int, int)>
        {
            (0,0),
            (0,1),
            (1,0),
            (0,0),
        };
        var newList = LogicPart1.RemoveRepeatedCoordinates(list);
        newList.Should().HaveCount(3);
    }

    [TestCase("U 2", 0, 2)]
    [TestCase("D 2", 0, -2)]
    [TestCase("R 2", 2, 0)]
    [TestCase("L 2", -2, 0)]
    [TestCase("L 20", -20, 0)]
    public void ConvertInstructionToCoordinates(string instruction, short x, short y)
    {
        (int resultX, int resultY) = LogicPart1.ConvertInstructionToCoordinates(instruction);
        resultX.Should().Be(x);
        resultY.Should().Be(y);
    }
}