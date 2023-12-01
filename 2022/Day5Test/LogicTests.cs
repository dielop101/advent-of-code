using _2022.Day5;
using FluentAssertions;
using Helpers;

namespace TemplateTest;

public class LogicTests
{
    [Test]
    public void Part1()
    {
        var message = Logic.Part(@"data\example.txt", false);

        message.Should().Be("CMZ");
    }

    [Test]
    public void Part2()
    {
        var message = Logic.Part(@"data\example.txt", true);

        message.Should().Be("MCD");
    }

    [Test]
    public void GetNumOfStacks()
    {
        var result = Logic.GetNumOfStacks(" 1   2   3 ");

        result.Should().Be(3);
    }

    [TestCase("    [D]    ", null, 'D', null)]
    [TestCase("[N] [C]    ", 'N', 'C', null)]
    [TestCase("[Z] [M] [P]", 'Z', 'M', 'P')]
    public void PopulateStacksofCrates(string input, char? result1, char? result2, char? result3)
    {
        var stacks = new Stack<char>[]
        {
            new Stack<char>(),
            new Stack<char>(),
            new Stack<char>()
        };
        Logic.PopulateStacksofCrates(stacks, input);

        if (result1.HasValue)
        {
            var char1 = stacks[0].Pop();
            char1.Should().Be(result1.Value);
        }
        else
        {
            stacks[0].Count.Should().Be(0);
        }
        if (result2.HasValue)
        {
            var char2 = stacks[1].Pop();
            char2.Should().Be(result2.Value);
        }
        else
        {
            stacks[1].Count.Should().Be(0);
        }
        if (result3.HasValue)
        {
            var char3 = stacks[2].Pop();
            char3.Should().Be(result3.Value);
        }
        else
        {
            stacks[2].Count.Should().Be(0);
        }
    }

    [Test]
    public void InitStacks()
    {
        var lines = ReadFile.Lines(@"data\examplemap.txt").ToArray();
        var result = Logic.InitStacks(lines);

        result.Length.Should().Be(3);
        result[0].Count.Should().Be(2);
        result[1].Count.Should().Be(3);
        result[2].Count.Should().Be(1);
    }

    [TestCase("move 1 from 2 to 1", 1, 2, 1)]
    [TestCase("move 3 from 1 to 3", 3, 1, 3)]
    [TestCase("move 30 from 10 to 30", 30, 10, 30)]
    public void ReadInstruction(string instruction, int numCratesEspected, int stackOriginSpected, int stackDestSpected)
    {
        (int numCrates, int stackOrigin, int stackDest) = Logic.ReadInstruction(instruction);

        numCrates.Should().Be(numCratesEspected);
        stackOrigin.Should().Be(stackOriginSpected);
        stackDest.Should().Be(stackDestSpected);
    }

    [Test]
    public void DoMovementPart1()
    {
        var lines = ReadFile.Lines(@"data\examplemap.txt").ToArray();
        var stacks = Logic.InitStacks(lines);

        Logic.DoMovement(stacks, "move 1 from 2 to 1", false);

        stacks[0].Count.Should().Be(3);
        stacks[1].Count.Should().Be(2);
        stacks[2].Count.Should().Be(1);

        var moved = stacks[0].Pop();
        moved.Should().Be('D');
    }

    [Test]
    public void DoMovementPart2()
    {
        var lines = ReadFile.Lines(@"data\examplemap.txt").ToArray();
        var stacks = Logic.InitStacks(lines);

        Logic.DoMovement(stacks, "move 3 from 2 to 1", true);

        stacks[0].Count.Should().Be(5);
        stacks[1].Count.Should().Be(0);
        stacks[2].Count.Should().Be(1);

        var moved = stacks[0].Pop();
        moved.Should().Be('D');
        moved = stacks[0].Pop();
        moved.Should().Be('C');
        moved = stacks[0].Pop();
        moved.Should().Be('M');
    }
}