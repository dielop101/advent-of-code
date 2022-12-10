using Helpers;

namespace Day10;

public static class Logic
{
    public static int Part1(string filepath)
    {
        var cycles = 0;
        var x = 1;
        var lines = ReadFile.Lines(filepath);
        var totalXWithCycles = 0;
        var nexCycle = 20;
        foreach (var instruction in lines)
        {
            (int newCycles, int newX) = OperateInstruction(instruction);
            while(newCycles > 0)
            {
                cycles++;

                if (cycles == nexCycle)
                {
                    totalXWithCycles += cycles * x;
                    nexCycle += 40;
                }

                newCycles--;

                if (newCycles == 0)
                {
                    x += newX;
                }
            }
        }

        return totalXWithCycles;
    }

    public static (int numCycles, int newValueX) OperateInstruction(string instruction)
    {
        if (instruction == "noop")
            return (1, 0);

        var instructionSplitted = instruction.Split(' ');
        var newValue = int.Parse(instructionSplitted[1]);
        return (2, newValue);
    }
}
