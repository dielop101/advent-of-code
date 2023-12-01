using Helpers;

namespace _2022.Day8;

public static class LogicPart1
{
    public static double Part1(string filepath)
    {
        var lines = ReadFile.Lines(filepath);
        var matrix = BuildMatrix(lines);
        var numOfTrees = 0;
        for (var y = 0; y < matrix.Length; y++)
        {
            var row = matrix[y];
            for (int x = 0; x < row.Length; x++)
            {
                numOfTrees += IsVisible(matrix, x, y) ? 1 : 0;
            }
        }

        return numOfTrees;
    }

    public static short[][] BuildMatrix(ICollection<string> lines)
    {
        var listOfLines = new List<short[]>();
        foreach (var line in lines)
        {
            listOfLines.Add(ConvertLineToString(line));
        }

        return listOfLines.ToArray();
    }

    public static bool IsVisible(short[][] matrix, int x, int y)
    {
        return IsVisibleTop(matrix, x, y) || IsVisibleBottom(matrix, x, y)
            || IsVisibleLeft(matrix, x, y) || IsVisibleRight(matrix, x, y);
    }

    public static bool IsVisibleTop(short[][] matrix, int x, int y)
    {
        var myTreeSize = matrix[y][x];

        int position = 1;
        while (matrix.Length > position)
        {
            if (y - position < 0)
                return true;

            var top = matrix[y - position][x];
            if (myTreeSize <= top)
            {
                return false;
            }
            position++;
        }

        return true;
    }

    public static bool IsVisibleBottom(short[][] matrix, int x, int y)
    {
        var myTreeSize = matrix[y][x];

        int position = 1;
        while (matrix.Length > position)
        {
            if (y + position > matrix.Length - 1)
                return true;

            var bottom = matrix[y + position][x];
            if (myTreeSize <= bottom)
            {
                return false;
            }
            position++;
        }

        return true;
    }

    public static bool IsVisibleLeft(short[][] matrix, int x, int y)
    {
        var myTreeSize = matrix[y][x];

        int position = 1;
        while (matrix[0].Length > position)
        {
            if (x - position < 0)
                return true;

            var left = matrix[y][x - position];
            if (myTreeSize <= left)
            {
                return false;
            }
            position++;
        }

        return true;
    }

    public static bool IsVisibleRight(short[][] matrix, int x, int y)
    {
        var myTreeSize = matrix[y][x];

        int position = 1;
        while (matrix[0].Length > position)
        {
            if (x + position > matrix[0].Length - 1)
                return true;

            var right = matrix[y][x + position];
            if (myTreeSize <= right)
            {
                return false;
            }
            position++;
        }

        return true;
    }

    public static short[] ConvertLineToString(string line)
    {
        return line.Select(c => short.Parse(c.ToString())).ToArray();
    }
}
