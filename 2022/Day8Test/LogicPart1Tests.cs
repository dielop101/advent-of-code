using _2022.Day8;
using FluentAssertions;

namespace Day8Test;

public class LogicPart1Tests
{
    [Test]
    public void Part1()
    {
        var result = LogicPart1.Part1(@"data\example.txt");
        result.Should().Be(21);
    }

    [TestCase(0, 0, true)]
    [TestCase(0, 1, true)]
    [TestCase(0, 2, true)]
    [TestCase(1, 0, true)]
    [TestCase(1, 1, false)]
    [TestCase(1, 2, true)]
    [TestCase(2, 0, true)]
    [TestCase(2, 1, true)]
    [TestCase(2, 2, true)]
    public void IsVisible(short x, short y, bool isVisible)
    {
        short[][] matrix = new short[][]
        {
            new short[] { 1, 3, 1 },
            new short[] { 3, 1, 3 },
            new short[] { 1, 3, 1 }
        };

        var result = LogicPart1.IsVisible(matrix, x, y);
        result.Should().Be(isVisible);
    }

    [TestCase(0, 0, true)]
    [TestCase(1, 0, true)]
    [TestCase(2, 0, true)]
    [TestCase(0, 1, true)]
    [TestCase(1, 1, false)]
    [TestCase(2, 1, false)]
    [TestCase(0, 2, false)]
    [TestCase(1, 2, false)]
    [TestCase(2, 2, false)]
    public void IsVisibleTop(short x, short y, bool isVisible)
    {
        short[][] matrix = new short[][]
        {
            new short[] { 1, 4, 1 },
            new short[] { 3, 1, 1 },
            new short[] { 1, 3, 1 }
        };

        var result = LogicPart1.IsVisibleTop(matrix, x, y);
        result.Should().Be(isVisible);
    }

    [TestCase(0, 0, false)]
    [TestCase(1, 0, true)]
    [TestCase(2, 0, false)]
    [TestCase(0, 1, true)]
    [TestCase(1, 1, false)]
    [TestCase(2, 1, false)]
    [TestCase(0, 2, true)]
    [TestCase(1, 2, true)]
    [TestCase(2, 2, true)]
    public void IsVisibleBottom(short x, short y, bool isVisible)
    {
        short[][] matrix = new short[][]
        {
            new short[] { 1, 4, 1 },
            new short[] { 3, 1, 1 },
            new short[] { 1, 3, 1 }
        };

        var result = LogicPart1.IsVisibleBottom(matrix, x, y);
        result.Should().Be(isVisible);
    }

    [TestCase(0, 0, true)]
    [TestCase(1, 0, true)]
    [TestCase(2, 0, false)]
    [TestCase(0, 1, true)]
    [TestCase(1, 1, false)]
    [TestCase(2, 1, false)]
    [TestCase(0, 2, true)]
    [TestCase(1, 2, true)]
    [TestCase(2, 2, false)]
    public void IsVisibleLeft(short x, short y, bool isVisible)
    {
        short[][] matrix = new short[][]
        {
            new short[] { 1, 4, 1 },
            new short[] { 3, 1, 1 },
            new short[] { 1, 3, 1 }
        };

        var result = LogicPart1.IsVisibleLeft(matrix, x, y);
        result.Should().Be(isVisible);
    }

    [TestCase(0, 0, false)]
    [TestCase(1, 0, true)]
    [TestCase(2, 0, true)]
    [TestCase(0, 1, true)]
    [TestCase(1, 1, false)]
    [TestCase(2, 1, true)]
    [TestCase(0, 2, false)]
    [TestCase(1, 2, true)]
    [TestCase(2, 2, true)]
    public void IsVisibleRight(short x, short y, bool isVisible)
    {
        short[][] matrix = new short[][]
        {
            new short[] { 1, 4, 1 },
            new short[] { 3, 1, 1 },
            new short[] { 1, 3, 1 }
        };

        var result = LogicPart1.IsVisibleRight(matrix, x, y);
        result.Should().Be(isVisible);
    }

    [Test]
    public void BuildMatrix()
    {
        var lines = new List<string>
        {
            "012",
            "345",
            "678",
        };

        var matrix = LogicPart1.BuildMatrix(lines);

        matrix[0][0].Should().Be(0);
        matrix[0][1].Should().Be(1);
        matrix[0][2].Should().Be(2);
        matrix[1][0].Should().Be(3);
        matrix[1][1].Should().Be(4);
        matrix[1][2].Should().Be(5);
        matrix[2][0].Should().Be(6);
        matrix[2][1].Should().Be(7);
        matrix[2][2].Should().Be(8);
    }

    [Test]
    public void ConvertLineToString()
    {
        var result = LogicPart1.ConvertLineToString("0123456789");

        result.Should().BeEquivalentTo(new short[]
        {
            0,1,2,3,4,5,6,7,8,9
        });
    }
}