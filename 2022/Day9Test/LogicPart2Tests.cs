using Day9;
using Day9.model;
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

    [Test]
    public void Movements()
    {
        var allPoints = new List<Point>
        {
            new Point("H"),
            new Point("1"),
            new Point("2"),
            new Point("3"),
            new Point("4"),
            new Point("5"),
            new Point("6"),
            new Point("7"),
            new Point("8"),
            new Point("9"),
        };

        LogicPart2.Movements(allPoints, "R 4");

        allPoints[0].CurrentX.Should().Be(4);
        allPoints[0].CurrentY.Should().Be(0);
        allPoints[1].CurrentX.Should().Be(3);
        allPoints[1].CurrentY.Should().Be(0);
        allPoints[2].CurrentX.Should().Be(2);
        allPoints[2].CurrentY.Should().Be(0);
        allPoints[3].CurrentX.Should().Be(1);
        allPoints[3].CurrentY.Should().Be(0);
        allPoints[4].CurrentX.Should().Be(0);
        allPoints[4].CurrentY.Should().Be(0);
        allPoints[5].CurrentX.Should().Be(0);
        allPoints[5].CurrentY.Should().Be(0);

        LogicPart2.Movements(allPoints, "U 4");

        allPoints[0].CurrentX.Should().Be(4);
        allPoints[0].CurrentY.Should().Be(4);
        allPoints[1].CurrentX.Should().Be(4);
        allPoints[1].CurrentY.Should().Be(3);
        allPoints[2].CurrentX.Should().Be(4);
        allPoints[2].CurrentY.Should().Be(2);
        allPoints[3].CurrentX.Should().Be(3);
        allPoints[3].CurrentY.Should().Be(2);
        allPoints[4].CurrentX.Should().Be(2);
        allPoints[4].CurrentY.Should().Be(2);
        allPoints[5].CurrentX.Should().Be(1);
        allPoints[5].CurrentY.Should().Be(1);
        allPoints[6].CurrentX.Should().Be(0);
        allPoints[6].CurrentY.Should().Be(0);

        LogicPart2.Movements(allPoints, "L 3");

        allPoints[0].CurrentX.Should().Be(1);
        allPoints[0].CurrentY.Should().Be(4);
        allPoints[1].CurrentX.Should().Be(2);
        allPoints[1].CurrentY.Should().Be(4);
        allPoints[2].CurrentX.Should().Be(3);
        allPoints[2].CurrentY.Should().Be(3);
        allPoints[3].CurrentX.Should().Be(3);
        allPoints[3].CurrentY.Should().Be(2);
        allPoints[4].CurrentX.Should().Be(2);
        allPoints[4].CurrentY.Should().Be(2);
        allPoints[5].CurrentX.Should().Be(1);
        allPoints[5].CurrentY.Should().Be(1);
        allPoints[6].CurrentX.Should().Be(0);
        allPoints[6].CurrentY.Should().Be(0);

        LogicPart2.Movements(allPoints, "D 1");

        allPoints[0].CurrentX.Should().Be(1);
        allPoints[0].CurrentY.Should().Be(3);
        allPoints[1].CurrentX.Should().Be(2);
        allPoints[1].CurrentY.Should().Be(4);
        allPoints[2].CurrentX.Should().Be(3);
        allPoints[2].CurrentY.Should().Be(3);
        allPoints[3].CurrentX.Should().Be(3);
        allPoints[3].CurrentY.Should().Be(2);
        allPoints[4].CurrentX.Should().Be(2);
        allPoints[4].CurrentY.Should().Be(2);
        allPoints[5].CurrentX.Should().Be(1);
        allPoints[5].CurrentY.Should().Be(1);
        allPoints[6].CurrentX.Should().Be(0);
        allPoints[6].CurrentY.Should().Be(0);

        LogicPart2.Movements(allPoints, "R 4");

        allPoints[0].CurrentX.Should().Be(5);
        allPoints[0].CurrentY.Should().Be(3);
        allPoints[1].CurrentX.Should().Be(4);
        allPoints[1].CurrentY.Should().Be(3);
        allPoints[2].CurrentX.Should().Be(3);
        allPoints[2].CurrentY.Should().Be(3);
        allPoints[3].CurrentX.Should().Be(3);
        allPoints[3].CurrentY.Should().Be(2);
        allPoints[4].CurrentX.Should().Be(2);
        allPoints[4].CurrentY.Should().Be(2);
        allPoints[5].CurrentX.Should().Be(1);
        allPoints[5].CurrentY.Should().Be(1);
        allPoints[6].CurrentX.Should().Be(0);
        allPoints[6].CurrentY.Should().Be(0);

    }
}