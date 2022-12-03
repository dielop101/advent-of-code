
using Helpers;

namespace Day3;
public static class Logic
{
    public static int Part1(string filepath)
    {
        var lines = ReadFile.Lines(filepath);

        var result = 0;
        foreach (var rucksacks in lines)
        {
            (string compatiment1,string compartiment2) = GetCompartiments(rucksacks);
            var letter = TakeRepeatedLetter(compatiment1, compartiment2);
            result += TransformLetterToValue(letter);
        }

        return result;
    }

    public static (string, string) GetCompartiments(string rucksacks)
    {
        return (rucksacks.Substring(0, rucksacks.Length / 2), rucksacks.Substring(rucksacks.Length / 2, rucksacks.Length / 2));
    }

    public static char TakeRepeatedLetter(string compartiment1, string compartiment2)
    {
        foreach (var candidateLetter in compartiment1)
        {
            if (compartiment2.Contains(candidateLetter))
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

