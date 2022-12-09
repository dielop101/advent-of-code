using Day9;
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
    public void FilterPathDependsOnTail1()
    {
        var path = new List<(int, int)>
        {
            (3, 4),
            (2, 4),
            (1, 4)
        };
        var result = LogicPart1.FilterPathDependsOnTail(path, (4, 3), (0,0));
        result.Should().HaveCount(2);
    }

    [Test]
    public void FilterPathDependsOnTail2()
    {
        var path = new List<(int, int)>
        {
            (1, 3),
            (2, 3),
            (3, 3),
            (4, 3)
        };
        var result = LogicPart1.FilterPathDependsOnTail(path, (2, 4), (0, 0)).ToList();
        result.Should().HaveCount(1);
        result[0].x.Should().Be(3);
        result[0].y.Should().Be(3);
    }

    [Test]
    public void FilterPathDependsOnTail3()
    {
        var path = LogicPart1.Movements((2, 0), "L 3").ToList();
        var result = LogicPart1.FilterPathDependsOnTail(path, (1, 0), (0, 0)).ToList();
        result.Should().HaveCount(1);
    }

    [Test]
    public void FilterPathDependsOnTail4()
    {
        var path = LogicPart1.Movements((2, 0), "L 3").ToList();
        var result = LogicPart1.FilterPathDependsOnTail(path, (1, 1), (0, 0)).ToList();
        result.Should().HaveCount(1);
        result[0].Should().BeEquivalentTo((0, 0));
    }

    [TestCase(1, "L 1", 0)]
    [TestCase(-1, "R 1", 0)]
    [TestCase(2, "L 1", 0)]
    [TestCase(-2, "R 1", 0)]
    public void FilterPathDependsOnTailPositionX(int x, string instruction, int total)
    {
        var path = LogicPart1.Movements((x, 0), instruction).ToList();
        var result = LogicPart1.FilterPathDependsOnTail(path, (0, 0), (0, 0)).ToList();
        result.Should().HaveCount(total);
    }

    [TestCase(-1, "U 1", 0)]
    [TestCase(1, "D 1", 0)]
    [TestCase(-2, "U 1", 0)]
    [TestCase(2, "D 1", 0)]
    public void FilterPathDependsOnTailPositionY(int y, string instruction, int total)
    {
        var path = LogicPart1.Movements((0, y), instruction).ToList();
        var result = LogicPart1.FilterPathDependsOnTail(path, (0, 0), (0, 0)).ToList();
        result.Should().HaveCount(total);
    }

    [Test]
    public void FilterPathDependsOnTail5()
    {
        var path = LogicPart1.Movements((1, 0), "L 1").ToList();
        var result = LogicPart1.FilterPathDependsOnTail(path, (0, 0), (0, 0)).ToList();
        result.Should().HaveCount(0);
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

    [Test]
    public void MoveUp()
    {
        var movements = LogicPart1.Movements((0, 0), "U 2").ToArray();
        movements.Should().HaveCount(2);
        movements[0].x.Should().Be(0);
        movements[0].y.Should().Be(1);
        movements[1].x.Should().Be(0);
        movements[1].y.Should().Be(2);
    }

    [Test]
    public void MoveDown()
    {
        var movements = LogicPart1.Movements((0, 0), "D 2").ToArray();
        movements.Should().HaveCount(2);
        movements[0].x.Should().Be(0);
        movements[0].y.Should().Be(-1);
        movements[1].x.Should().Be(0);
        movements[1].y.Should().Be(-2);
    }

    [Test]
    public void MoveRight()
    {
        var movements = LogicPart1.Movements((0, 0), "R 2").ToArray();
        movements.Should().HaveCount(2);
        movements[0].x.Should().Be(1);
        movements[0].y.Should().Be(0);
        movements[1].x.Should().Be(2);
        movements[1].y.Should().Be(0);
    }

    [Test]
    public void MoveLeft()
    {
        var movements = LogicPart1.Movements((0, 0), "L 2").ToArray();
        movements.Should().HaveCount(2);
        movements[0].x.Should().Be(-1);
        movements[0].y.Should().Be(0);
        movements[1].x.Should().Be(-2);
        movements[1].y.Should().Be(0);
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