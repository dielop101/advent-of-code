using Helpers;

namespace Day5;
public static class Logic
{
    public static string Part(string filepath, bool part2)
    {
        var lines = ReadFile.LinesGroupedBySpace(filepath);
        var map = lines.First();
        var instructions = lines.Last();

        var stacks = InitStacks(map.ToArray());
        foreach (var instruction in instructions)
        {
            DoMovement(stacks, instruction, part2);
        }

        var listOfChars = stacks.Select(x => x.Pop());
        return string.Join("", listOfChars);
    }

    public static void DoMovement(Stack<char>[] stacks, string instruction, bool part2)
    {
        (int numCrates, int stackOriginId, int stackDestId) = ReadInstruction(instruction);

        var stackOrigin = stacks[stackOriginId - 1];
        var stackDest = stacks[stackDestId - 1];

        var listOfCrates = new List<char>();
        for (int i = 0; i < numCrates; i++)
        {
            listOfCrates.Add(stackOrigin.Pop());
        }

        if (part2)
        {
            listOfCrates.Reverse();
        }

        foreach (var crate in listOfCrates)
        {
            stackDest.Push(crate);
        }
    }

    public static (int numCrates, int stackOrigin, int stackDest) ReadInstruction(string instruction)
    {
        var instructionClean = instruction
            .Replace("move ", "")
            .Replace("from ", "")
            .Replace("to ", "");

        var numbers = instructionClean.Split(' ');

        return (int.Parse(numbers[0]), int.Parse(numbers[1]), int.Parse(numbers[2]));
    }

    public static Stack<char>[] InitStacks(string[] lines)
    {
        var numOfStacks = GetNumOfStacks(lines[^1]);
        var stacks = new Stack<char>[numOfStacks];
        stacks = stacks.Select(x => new Stack<char>()).ToArray();

        for (int i = lines.Length - 2; i >= 0; i--)
        {
            PopulateStacksofCrates(stacks, lines[i]);
        }

        return stacks;
    }

    public static int GetNumOfStacks(string input)
    {
        return input
            .Split(' ')
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(int.Parse)
            .Last();
    }

    public static void PopulateStacksofCrates(Stack<char>[] stacks, string input)
    {
        var countLetters = 0;
        var countStacks = 0;
        var stringLetter = string.Empty;
        foreach (var character in input)
        {
            stringLetter += character;
            countLetters++;

            if (countLetters == 4) //" [A] " -> 5 chars
            {
                if (!string.IsNullOrWhiteSpace(stringLetter))
                {
                    var stack = stacks[countStacks];
                    stack.Push(stringLetter[1]);
                }

                stringLetter = string.Empty;
                countLetters = 0;
                countStacks++;
            }
        }

        //el último no tiene espacio al final para hacer el count == 4
        if (!string.IsNullOrWhiteSpace(stringLetter))
        {
            var stack = stacks[countStacks];
            stack.Push(stringLetter[1]);
        }
    }
}

