using Helpers;

namespace _2022.Day6;
public static class Logic
{
    public static int Part(string filepath, int length)
    {
        var lines = ReadFile.Lines(filepath);

        return GetIndex(lines.First(), length);
    }

    public static int GetIndex(string message, int length)
    {
        var index = 0;

        while(index < message.Length)
        {
            var nexString = MoveNext(message, index, length);
            if (ContainsUniqueChars(nexString))
            {
                return index + length;   //+length since we get length characters, so last index is first index + length
            }
            index++;
        }

        throw new Exception("index not found");
    }

    public static string MoveNext(string @string, int index, int length)
    {
        return @string.Substring(index, length);
    }

    public static bool ContainsUniqueChars(string input)
    {
        return input.All(x => input.Count(y => y.Equals(x)) == 1);
    }
}
