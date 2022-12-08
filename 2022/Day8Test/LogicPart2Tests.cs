using Day8;
using FluentAssertions;
using Helpers;

namespace Day8Test;

public class LogicPart2Tests
{
    [TestCase(2, 1, 4)]
    [TestCase(2, 3, 8)]
    public void TotalOfTrees(int x, int y, int numOfTrees)
    {
        var lines = ReadFile.Lines(@"data\example.txt");
        var matrix = LogicPart2.BuildMatrix(lines);
        var result = LogicPart2.TotalOfTrees(matrix, x, y);
        result.Should().Be(numOfTrees);
    }

    [TestCase(0, 0, 0)]
    [TestCase(1, 0, 0)]
    [TestCase(2, 0, 0)]
    [TestCase(0, 1, 1)]
    [TestCase(1, 1, 1)]
    [TestCase(2, 1, 1)]
    [TestCase(0, 2, 1)]
    [TestCase(1, 2, 2)]
    [TestCase(2, 2, 1)]
    public void NumOfTreesVisibleTop(short x, short y, int numTreesVisibles)
    {
        short[][] matrix = new short[][]
        {
            new short[] { 1, 4, 1 },
            new short[] { 3, 1, 1 },
            new short[] { 1, 3, 1 }
        };

        var result = LogicPart2.NumOfTreesVisibleTop(matrix, x, y);
        result.Should().Be(numTreesVisibles);
    }

    [TestCase(0, 0, 1)]
    [TestCase(1, 0, 2)]
    [TestCase(2, 0, 1)]
    [TestCase(0, 1, 1)]
    [TestCase(1, 1, 1)]
    [TestCase(2, 1, 1)]
    [TestCase(0, 2, 0)]
    [TestCase(1, 2, 0)]
    [TestCase(2, 2, 0)]
    public void NumOfTreesVisibleBottom(short x, short y, int numTreesVisibles)
    {
        short[][] matrix = new short[][]
        {
            new short[] { 1, 4, 1 },
            new short[] { 3, 1, 1 },
            new short[] { 1, 3, 1 }
        };

        var result = LogicPart2.NumOfTreesVisibleBottom(matrix, x, y);
        result.Should().Be(numTreesVisibles);
    }

    [TestCase(0, 0, 0)]
    [TestCase(1, 0, 1)]
    [TestCase(2, 0, 1)]
    [TestCase(0, 1, 0)]
    [TestCase(1, 1, 1)]
    [TestCase(2, 1, 1)]
    [TestCase(0, 2, 0)]
    [TestCase(1, 2, 1)]
    [TestCase(2, 2, 2)]
    public void NumOfTreesVisibleLeft(short x, short y, int numTreesVisibles)
    {
        short[][] matrix = new short[][]
        {
            new short[] { 1, 4, 1 },
            new short[] { 3, 1, 1 },
            new short[] { 1, 1, 2 }
        };

        var result = LogicPart2.NumOfTreesVisibleLeft(matrix, x, y);
        result.Should().Be(numTreesVisibles);
    }

    [TestCase(0, 0, 1)]
    [TestCase(1, 0, 1)]
    [TestCase(2, 0, 0)]
    [TestCase(0, 1, 2)]
    [TestCase(1, 1, 1)]
    [TestCase(2, 1, 0)]
    [TestCase(0, 2, 1)]
    [TestCase(1, 2, 1)]
    [TestCase(2, 2, 0)]
    public void NumOfTreesVisibleRight(short x, short y, int numTreesVisibles)
    {
        short[][] matrix = new short[][]
        {
            new short[] { 1, 4, 1 },
            new short[] { 3, 1, 1 },
            new short[] { 1, 3, 1 }
        };

        var result = LogicPart2.NumOfTreesVisibleRight(matrix, x, y);
        result.Should().Be(numTreesVisibles);
    }
}