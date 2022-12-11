using Helpers;

namespace Day10;

public static class LogicPart2
{
    public static bool[][] Part2(string filepath)
    {
        var cycles = 0;
        var y = 0;
        var x = 1;  //should cover 0, 1 and 2
        var lines = ReadFile.Lines(filepath);
        var crt = BuildCRT(40, 6);
        foreach (var instruction in lines)
        {
            (int newCycles, int newX) = OperateInstruction(instruction);
            while(newCycles > 0)
            {
                cycles++;

                if (cycles % 40 == 0)
                {
                    cycles = 0; //reset cycle(pointer x) and next y;
                    y++;
                }

                if (cycles > 0)
                    PrintPixel(crt, cycles - 1, x, y);

                newCycles--;

                if (newCycles == 0)
                {
                    x += newX;
                }
            }
        }

        PrintConsole(crt);

        return crt;
    }

    private static void PrintConsole(bool[][] crt)
    {
        foreach (var array in crt)
        {
            foreach (var item in array)
            {
                Console.Write(item ? "#" : ".");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static (int numCycles, int newValueX) OperateInstruction(string instruction)
    {
        if (instruction == "noop")
            return (1, 0);

        var instructionSplitted = instruction.Split(' ');
        var newValue = int.Parse(instructionSplitted[1]);
        return (2, newValue);
    }

    public static bool[][] BuildCRT(int x, int y)
    {
        var listy = new List<bool[]>();
        var originx = x;
        while (y > 0)
        {
            var listx = new List<bool>();
            x = originx;
            while (x > 0)
            {
                listx.Add(false);
                x--;
            }
            listy.Add(listx.ToArray());
            y--;
        }

        return listy.ToArray();
    }

    public static void PrintPixel(bool[][] crt,int cycle, int x, int y)
    {
        crt[y][cycle] = (cycle == x || cycle == x - 1 || cycle == x + 1);
    }
}
