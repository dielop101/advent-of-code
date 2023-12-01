using Helpers;

namespace Day01;

public static class Logic
{
    private readonly static string[] _numbers = new[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    public static int SumCalibratedValues(string filepath)
    {
        var lines = ReadFile.Lines(filepath);

        var total = 0;
        foreach (var line in lines)
        {
            total += SumCalibratedValuesPerLine(line);
        }

        return total;
    }

    private static int SumCalibratedValuesPerLine(string line)
    {
        var intLists = new List<int>();
        for (int i = 0; i < line.Length; i++)
        {
            var charLine = line[i];

            if (int.TryParse(charLine.ToString(), out int value))
            {
                intLists.Add(value);
            }
            else
            {
                for (int j = 0; j < _numbers.Length; j++)
                {
                    var numberWord = _numbers[j];
                    if (TryGetNumber(line, i, numberWord))
                    {
                        intLists.Add(j + 1);
                    }
                }
            }
        }

        return intLists[0] * 10 + intLists[intLists.Count - 1];
    }

    private static bool TryGetNumber(string line, int i, string numberExpected)
    {
        return (numberExpected.Length + i) <= line.Length &&
             line.Substring(i, numberExpected.Length).Equals(numberExpected);
    }
}
