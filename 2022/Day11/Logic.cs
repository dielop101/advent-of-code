using Day11.model;
using Helpers;

namespace Day11;

public static class Logic
{
    public static int Part1(string filepath, int rounds)
    {
        var monkeys = DoRounds(filepath, rounds);
        var inspected = monkeys.Select(x => x.InspectsItems).OrderByDescending(x => x).ToList();
        return inspected[0] * inspected[1];
    }

    public static List<Monkey> DoRounds(string filepath, int rounds)
    {
        var monkeys = InitMonkeys(filepath);
        while(rounds > 0)
        {
            foreach (var monkey in monkeys)
            {
                monkey.DoAction(monkeys);
            }
            rounds--;
        }

        return monkeys;
    }

    public static List<Monkey> InitMonkeys(string filepath)
    {
        var lines = ReadFile.LinesGroupedBySpace(filepath);
        var listOfMonkeys = new List<Monkey>();
        foreach (var monkeyLines in lines)
        {
            var monkeyLinesArray = monkeyLines.ToArray();
            var monkey = new Monkey(monkeyLinesArray[0], monkeyLinesArray[1], monkeyLinesArray[2],
                monkeyLinesArray[3], monkeyLinesArray[4], monkeyLinesArray[5]);

            listOfMonkeys.Add(monkey);
        }

        return listOfMonkeys;
    }
}
