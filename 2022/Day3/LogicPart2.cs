
using Helpers;

namespace _2022.Day3;
public static class LogicPart2
{
    public static int Part2(string filepath)
    {
        var linesGrouped = ReadFile.LinesGroupBy(filepath, 3);
        var result = 0;
        foreach (var lines in linesGrouped)
        {
            var linesArray = lines.ToArray();
            var letter = TakeRepeatedLetter(linesArray[0], linesArray[1], linesArray[2]);
            result += TransformLetterToValue(letter);
        }

        return result;
    }

    public static char TakeRepeatedLetter(string rucksack1, string rucksack2, string rucksack3)
    {
        foreach (var candidateLetter in rucksack1)
        {
            if (rucksack2.Contains(candidateLetter) && rucksack3.Contains(candidateLetter))
                return candidateLetter;
        }

        throw new Exception("not found");
    }

    public static int TransformLetterToValue(char letter)
    {
        var result = letter % 32;
        return char.IsUpper(letter) ? result + 26 : result;
    }
}

