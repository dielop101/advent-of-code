using Day7;
using FluentAssertions;
using Helpers;

namespace Day7Test;

public class LogicTests
{
    [Test]
    public void Part1()
    {
        var result = Logic.Part1(@"data\example.txt");
        result.Should().Be(95437);
    }

    [Test]
    public void Part2()
    {
        var result = Logic.Part2(@"data\example.txt");
        result.Should().Be(24933642);
    }

    [Test]
    public void SpaceNeeded()
    {
        var lines = ReadFile.Lines(@"data\example.txt");
        var createStructure = Logic.CreateStructure(lines);
        var spaceNeeded = Logic.SpaceNeeded(createStructure);
        spaceNeeded.Should().Be(8381165);
    }

    [Test]
    public void CreateStructure()
    {
        var lines = new List<string>
        {
            "$ cd /",
            "$ ls",
            "dir a",
            "100 b.txt",
            "200 c.dat",
            "dir d"
        };
        var result = Logic.CreateStructure(lines);

        result.Directories.Should().HaveCount(2);
        result.Size.Should().Be(300);
    }

    [TestCase("$ cd /", true, false, false, "cd", "/", null)]
    [TestCase("$ ls", true, false, false, "ls", null, null)]
    [TestCase("dir e", false, true, false, "e", null, null)]
    [TestCase("62596 h.lst", false, false, true, "h.lst", null, 62596)]
    public void ConvertInstruction(string command, bool isT0, bool isT1, bool isT2, string name, string? args, double? size)
    {
        var result = Logic.ConvertInstruction(command);

        result.IsT0.Should().Be(isT0);
        result.IsT1.Should().Be(isT1);
        result.IsT2.Should().Be(isT2);

        if (isT0)
        {
            result.AsT0.Name.Should().Be(name);
            result.AsT0.Args.Should().Be(args);
        }
        else if (isT1)
        {
            result.AsT1.Name.Should().Be(name);
        }
        else if (isT2)
        {
            result.AsT2.Should().Be(size);
        }
    }
}