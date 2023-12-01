using _2022.Day12;
using FluentAssertions;

namespace Day12Test;

public class LogicTest
{

    [Test]
    public void Part1()
    {
        var result = Logic.Part1(@"data\example.txt");
        result.Should().Be(31);
    }

    [Test]
    public void CreateMatrix()
    {
        var matrix = Logic.CreateMatrix(@"data\example.txt");
        matrix.Length.Should().Be(5);
        matrix[0].Length.Should().Be(8);
        matrix[0][0].Should().Be(Logic.START);
        matrix[2][5].Should().Be(Logic.END);
    }

    [Test]
    public void FindStartPoint()
    {
        var matrix = new char[][]{
            "as".ToCharArray(),
            "cS".ToCharArray(),
        };

        var result = Logic.FindStartPoint(matrix);
        result.Should().Be((1,1));
    }

    [TestCase('a', 'b', true)]
    [TestCase('a', 'c', false)]
    [TestCase('b', 'a', false)]
    [TestCase('b', null, false)]
    [TestCase('S', 'a', true)]
    [TestCase('S', 'b', false)]
    [TestCase('a', 'a', true)]
    public void IsPossiblePath(char char1, char? char2, bool expected)
    {
        var result = Logic.IsPossiblePath(char1, char2);
        result.Should().Be(expected);
    }

    [TestCase(0, 0, null)]
    [TestCase(0, 1, 'a')]
    public void GetTop(int x, int y, char? expected)
    {
        var position = (x, y);
        var matrix = new char[][]{
            "ab".ToCharArray(),
            "cd".ToCharArray(),
        };
        var result = Logic.GetTop(matrix, position);
        result.Should().Be(expected);
    }

    [TestCase(0, 0, 'c')]
    [TestCase(0, 1, null)]
    public void GetBottom(int x, int y, char? expected)
    {
        var position = (x, y);
        var matrix = new char[][]{
            "ab".ToCharArray(),
            "cd".ToCharArray(),
        };
        var result = Logic.GetBottom(matrix, position);
        result.Should().Be(expected);
    }

    [TestCase(0, 0, null)]
    [TestCase(1, 0, 'a')]
    public void GetLeft(int x, int y, char? expected)
    {
        var position = (x, y);
        var matrix = new char[][]{
            "ab".ToCharArray(),
            "cd".ToCharArray(),
        };
        var result = Logic.GetLeft(matrix, position);
        result.Should().Be(expected);
    }

    [TestCase(0, 0, 'b')]
    [TestCase(1, 0, null)]
    public void GetRight(int x, int y, char? expected)
    {
        var position = (x, y);
        var matrix = new char[][]{
            "ab".ToCharArray(),
            "cd".ToCharArray(),
        };
        var result = Logic.GetRight(matrix, position);
        result.Should().Be(expected);
    }
}